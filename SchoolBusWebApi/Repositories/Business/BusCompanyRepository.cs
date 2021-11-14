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
    public class BusCompanyRepository : BaseReprository,IBusCompanyRepository
    {
        public BusCompanyRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<int> Add(BusCompanyDto item)
        {
            var Data = _mapper.Map<BusCompany>(item);
            Data.CreateTime = DateTime.Now;
            _context.BusCompanies.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public void Delete(int id)
        {
            _context.BusCompanies.Remove(new BusCompany() { Id = id });
        }

        public async Task<bool> Update(BusCompanyDto item)
        {
            var Data = await _context.BusCompanies.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<BusCompanyDto>> GetAsync()
        {
            var query = _context.BusCompanies.AsQueryable();

            return await query.ProjectTo<BusCompanyDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PagedList<BusCompanyDto>> GetByParamAsync(BusCompanyParams Param)
        {
            var query = _context.BusCompanies.ProjectTo<BusCompanyDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(Param.Address))
                query = query.Where(r => r.Address.Contains(Param.Address));

            if (!string.IsNullOrEmpty(Param.Company))
                query = query.Where(r => r.Company.Contains(Param.Company));
          
            return await PagedList<BusCompanyDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
