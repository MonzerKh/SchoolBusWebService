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
    public class Driver_BusRepository : BaseReprository,IDriver_BusRepository
    {
        public Driver_BusRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task Add(Driver_BusDto item)
        {
            var Data = _mapper.Map<Driver_Bus>(item);
            Data.CreateTime = DateTime.Now;
            _context.Driver_Buses.Add(Data);
            await _context.SaveChangesAsync();
        }

        public void Delete(int bus_Id, int driver_Id)
        {
            _context.Driver_Buses.Remove(new Driver_Bus() { Bus_Id = bus_Id, Driver_Id = driver_Id });
        }

        public async Task<bool> Update(Driver_BusDto item)
        {
            var Data = await _context.Driver_Buses.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Driver_BusDto>> GetAsync()
        {
            var query = _context.Driver_Buses.AsQueryable();

            return await query.ProjectTo<Driver_BusDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PagedList<Driver_BusDto>> GetByParamAsync(Driver_BusParams Param)
        {
            var query = _context.Driver_Buses.ProjectTo<Driver_BusDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            //if (!string.IsNullOrEmpty(Param.Driver_Bus_Name))
            //    query = query.Where(r => r.Driver_Bus_Name.Contains(Param.Driver_Bus_Name));

            //if (!string.IsNullOrEmpty(Param.Manager))
            //    query = query.Where(r => r.Manager.Contains(Param.Manager));
            //if (Param.Address != null)
            //    query = query.Where(r => r.Address.Contains(Param.Address));

            return await PagedList<Driver_BusDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
