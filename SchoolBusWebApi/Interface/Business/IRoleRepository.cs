using ModelsLayer.Dtos.Permission;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface
{
    public interface IRoleRepository
    {
        Task<List<RolesDto>> GetAsync();
        Task<PagedList<RolesDto>> GetByParamAsync(RoleParams Param);
        Task<int> Add(RolesDto role);
        void Delete(int id);
        Task<bool> Update(RolesDto role);
    }
}
