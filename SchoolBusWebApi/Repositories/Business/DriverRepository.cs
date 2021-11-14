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

        public async Task<PagedList<DriverDto>> GetByParamAsync(DriverParams Param)
        {
            var query = _context.Drivers.ProjectTo<DriverDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            //if (!string.IsNullOrEmpty(Param.Driver_Name))
            //    query = query.Where(r => r.Driver_Name.Contains(Param.Driver_Name));

            //if (!string.IsNullOrEmpty(Param.Manager))
            //    query = query.Where(r => r.Manager.Contains(Param.Manager));
            //if (Param.Address != null)
            //    query = query.Where(r => r.Address.Contains(Param.Address));

            return await PagedList<DriverDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
