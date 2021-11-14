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
    public class GuardianRepository : BaseReprository,IGuardianRepository
    {
        public GuardianRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<int> Add(GuardianDto item)
        {
            var Data = _mapper.Map<Guardian>(item);
            Data.CreateTime = DateTime.Now;
            _context.Guardians.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public void Delete(int id)
        {
            _context.Guardians.Remove(new Guardian() { Id = id });
        }

        public async Task<bool> Update(GuardianDto item)
        {
            var Data = await _context.Guardians.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<GuardianDto>> GetAsync()
        {
            var query = _context.Guardians.AsQueryable();

            return await query.ProjectTo<GuardianDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PagedList<GuardianDto>> GetByParamAsync(GuardianParams Param)
        {
            var query = _context.Guardians.ProjectTo<GuardianDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            //if (!string.IsNullOrEmpty(Param.Guardian_Name))
            //    query = query.Where(r => r.Guardian_Name.Contains(Param.Guardian_Name));

            //if (!string.IsNullOrEmpty(Param.Manager))
            //    query = query.Where(r => r.Manager.Contains(Param.Manager));
            //if (Param.Address != null)
            //    query = query.Where(r => r.Address.Contains(Param.Address));

            return await PagedList<GuardianDto>.CreateAsync(query, Param.PageNumber, Param.PageSize);
        }
    }
}
