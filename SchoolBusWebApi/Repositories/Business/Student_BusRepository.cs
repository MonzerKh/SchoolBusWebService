using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using ModelsLayer.Helper;
using ModelsLayer.Models;
using ModelsLayer.Params;
using SchoolBusWebApi.Interface.Business;
using SchoolBusWebApi.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Repositories.Business
{
    public class Student_BusRepository : BaseReprository, IStudent_BusRepository
    {
        public Student_BusRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }
       
        public async Task<int> Add(Student_BusDto item)
        {
            var Data = _mapper.Map<Student_Bus>(item);
            Data.CreateTime = DateTime.Now;
            _context.Student_Buses.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public async void AddAsync(Student_BusDto item)
        {
            var Data = _mapper.Map<Student_Bus>(item);
            Data.CreateTime = DateTime.Now;
            _context.Student_Buses.Add(Data);
        }

        public async Task<bool> Update(Student_BusDto item)
        {
            var Data = await _context.Student_Buses.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public void Delete(int id)
        {
            _context.Student_Buses.Remove(new Student_Bus() { Id = id });
        }

        public async void DeActivatedPerviousBus(int id,int user_id)
        {
            var Data = await _context.Student_Buses.Where(r => r.Student_Id == id && r.IsActive == true).FirstOrDefaultAsync();
            if (Data !=null)
            {
                Data.IsActive = false;
                Data.UpdateTime = DateTime.Now;
                _context.Entry(Data).State = EntityState.Modified;
            }

        }

        public async Task<List<Student_BusDto>> GetAsync(StudentBusParams Params)
        {
            var query = _context.Student_Buses.AsQueryable();

            return await Params.AddFilter(query).ProjectTo<Student_BusDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<Student_BusDto> GetByIdAsync(int Id)
        {
            var query = _context.Student_Buses.Where(r => r.Id == Id).AsQueryable();

            return await query.ProjectTo<Student_BusDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<List<StudentBusListDto>> GetListAsync(StudentBusParams Params)
        {
            var query = _context.Student_Buses.AsQueryable();
           // var query2 = Params.AddFilter(query).ProjectTo<StudentBusListDto>(_mapper.ConfigurationProvider);
            return await Params.AddFilter(query).ProjectTo<StudentBusListDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PagedList<Student_BusDto>> GetPagingAsync(StudentBusParams Params)
        {
            var query = Params.AddFilter(_context.Student_Buses.AsQueryable()).ProjectTo<Student_BusDto>(_mapper
            .ConfigurationProvider).AsQueryable().AsNoTracking();

            return await PagedList<Student_BusDto>.CreateAsync(query,
                Params.PageNumber, Params.PageSize);
        }

        public  async Task<List<LocationPeer>> GetStudentBusTSP(StudentBusParams Params)
        {
            var Peers = await Params.AddFilter(_context.Student_Buses.AsQueryable()).ProjectTo<LocationPeer>(_mapper.ConfigurationProvider)
                .AsQueryable().AsNoTracking().ToListAsync();

            var SchoolLocation = await _context.Schools.ProjectTo<LocationPeer>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

   

            var Tree = new TSP_Tree(SchoolLocation);
            Tree.CreateRoadsMap(Peers);

            var Result = Tree.FindShortPathTree2();
            Result.Reverse();
            return Result;
        }
    }
}
