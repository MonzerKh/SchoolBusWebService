using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables;
using ModelsLayer.Dtos.Business;
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
    public class SupervisorRepository : BaseReprository,ISupervisorRepository
    {
        public SupervisorRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<int> Add(SupervisorDto item)
        {
            var Data = _mapper.Map<Supervisor>(item);
            Data.CreateTime = DateTime.Now;
            _context.Supervisors.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public void Delete(int id)
        {
            _context.Supervisors.Remove(new Supervisor() { Id = id });
        }

        public async Task<bool> Update(SupervisorDto item)
        {
            var Data = await _context.Supervisors.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<SupervisorDto>> GetAsync()
        {
            var query = _context.Supervisors.AsQueryable();

            return await query.ProjectTo<SupervisorDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PagedList<SupervisorDto>> GetByParamAsync(SupervisorParams Param)
        {
            var query = _context.Supervisors.ProjectTo<SupervisorDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            //if (!string.IsNullOrEmpty(Param.Supervisor_Name))
            //    query = query.Where(r => r.Supervisor_Name.Contains(Param.Supervisor_Name));

            //if (!string.IsNullOrEmpty(Param.Manager))
            //    query = query.Where(r => r.Manager.Contains(Param.Manager));
            //if (Param.Address != null)
            //    query = query.Where(r => r.Address.Contains(Param.Address));

            return await PagedList<SupervisorDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
