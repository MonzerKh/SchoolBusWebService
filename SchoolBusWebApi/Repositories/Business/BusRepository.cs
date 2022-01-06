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
    public class BusRepository : BaseReprository,IBusRepository
    {
        public BusRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<int> Add(BusDto item)
        {
            var Data = _mapper.Map<Bus>(item);
            Data.CreateTime = DateTime.Now;
            Data.CreatedBy = item.CreatedBy;
            _context.Buses.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public void Delete(int id)
        {
            _context.Buses.Remove(new Bus() { Id = id });
        }

        public async Task<bool> Update(BusDto item)
        {
            var Data = await _context.Buses.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<BusDto>> GetAsync()
        {
            var query = _context.Buses.AsQueryable();

            return await query.ProjectTo<BusDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<BusDto> GetByIdAsync(int Id)
        {
            var query = _context.Buses.Where(r => r.Id == Id).AsQueryable();

            return await query.ProjectTo<BusDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }




        public async Task<PagedList<BusDto>> GetByParamAsync(BusParams Param)
        {
            var query = _context.Buses.ProjectTo<BusDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(Param.Number))
                query = query.Where(r => r.Number.Contains(Param.Number));

            if (!string.IsNullOrEmpty(Param.Marka))
                query = query.Where(r => r.Marka.Contains(Param.Marka));
            if (Param.Company != null)
                query = query.Where(r => r.Company.Contains(Param.Company));
            if (Param.Capacity != null)
                query = query.Where(r => r.Capacity == Param.Capacity);

            return await PagedList<BusDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
