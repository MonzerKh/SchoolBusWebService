using AutoMapper;
using DataAccessLayer.DataAccess;
using ModelsLayer.Dtos.Permission;
using SchoolBusWebApi.Interface;
using ModelsLayer.Params;
using SchoolBusWebApi.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer.Helper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables.Permissions;

namespace SchoolBusWebApi.Repositories
{
    public class RoleRepository : BaseReprository,IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<int> Add(RolesDto item)
        {
            var role = _mapper.Map<SysRole>(item);
            _context.SysRoles.Add(role);
            await _context.SaveChangesAsync();
            return role.Id;
        }

        public void Delete(int id)
        {
            _context.SysRoles.Remove(new SysRole() { Id = id });
        }

        public async Task<bool> Update(RolesDto item)
        {
            var role = await _context.SysRoles.FindAsync(item.Id);
            _mapper.Map(item, role);
            _context.Entry(role).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<RolesDto>> GetAsync()
        {
            var query = _context.SysRoles.AsQueryable();

            return await query.ProjectTo<RolesDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PagedList<RolesDto>> GetByParamAsync(RoleParams Param)
        {
            var query = _context.SysRoles.ProjectTo<RolesDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(Param.Role))
                query = query.Where(r => r.Role.Contains(Param.Role));
            if (Param.RoleType != null)
                query = query.Where(r => r.RoleType == Param.RoleType);

            return await PagedList<RolesDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }

       
    }
}
