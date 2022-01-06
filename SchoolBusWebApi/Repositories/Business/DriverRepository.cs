using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using SchoolBusWebApi.Interface.Business;
using SchoolBusWebApi.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Repositories.Business
{
    public class DriverRepository : BaseReprository,IDriverRepository
    {
        public DriverRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<int> Add(DriverDto item)
        {
            var Data = _mapper.Map<Driver>(item);
            Data.CreateTime = DateTime.Now;
            _context.Drivers.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public void Delete(int id)
        {
            _context.Drivers.Remove(new Driver() { Id = id });
        }

        public async Task<bool> Update(DriverDto item)
        {
            var Data = await _context.Drivers.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<DriverDto>> GetAsync()
        {
            var query = _context.Drivers.AsQueryable();

            return await query.ProjectTo<DriverDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

         public async Task<List<DriverListDto>> GetListAsync()
        {
            var query = _context.Drivers.AsQueryable();

            return await query.ProjectTo<DriverListDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
		

        public async Task<PagedList<DriverDto>> GetByParamAsync(DriverParams Param)
        {
            var query = _context.Drivers.ProjectTo<DriverDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(Param.Company))
                query = query.Where(r => r.Company.Contains(Param.Company));
            if (!string.IsNullOrEmpty(Param.Email))
                query = query.Where(r => r.Email.Contains(Param.Email));
            if (!string.IsNullOrEmpty(Param.Full_Name))
                query = query.Where(r => r.Full_Name.Contains(Param.Full_Name));
            if (!string.IsNullOrEmpty(Param.National_Number))
                query = query.Where(r => r.National_Number.Contains(Param.National_Number));
            if (!string.IsNullOrEmpty(Param.Phone))
                query = query.Where(r => r.Phone.Contains(Param.Phone));
            if (!string.IsNullOrEmpty(Param.Company))
                query = query.Where(r => r.UserName.Contains(Param.UserName));

            return await PagedList<DriverDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
