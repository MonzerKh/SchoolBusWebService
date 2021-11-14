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
    public class SchoolRepository : BaseReprository,ISchoolRepository
    {
        public SchoolRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<int> Add(SchoolDto item)
        {
            var Data = _mapper.Map<School>(item);
            Data.CreateTime = DateTime.Now;
            Data.CreateUser_Id = item.CreatedBy;
            _context.Schools.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public void Delete(int id)
        {
            _context.Schools.Remove(new School() { Id = id });
        }

        public async Task<bool> Update(SchoolDto item)
        {
            var Data = await _context.Schools.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<SchoolDto>> GetAsync()
        {
            var query = _context.Schools.AsQueryable();

            return await query.ProjectTo<SchoolDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PagedList<SchoolDto>> GetByParamAsync(SchoolParams Param)
        {
            var query = _context.Schools.ProjectTo<SchoolDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(Param.School_Name))
                query = query.Where(r => r.School_Name.Contains(Param.School_Name));

            if (!string.IsNullOrEmpty(Param.Manager))
                query = query.Where(r => r.Manager.Contains(Param.Manager));
            if (Param.Address != null)
                query = query.Where(r => r.Address.Contains(Param.Address));

            return await PagedList<SchoolDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
