using ModelsLayer.DataLayer.Tables.Permissions;
using ModelsLayer.Dtos.SystemUsers;
using ModelsLayer.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface
{
    public interface ISystemUserRepository
    {
        Task<List<SystemUserDto>> GetAsync();
      //  Task<PagedList<SystemUserDto>> GetByParamAsync(SystemUserParams Param);
        Task<int> Add(SystemUserDto SystemUser);
        void Delete(int id);
        Task<bool> Update(SystemUserDto SystemUser);
        Task<SystemUserDto> Login(LoginDto loginDto);
        Task<bool> UserExists(string username);
    }
}
