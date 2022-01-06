using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables.Permissions;
using ModelsLayer.Dtos.DropList;
using ModelsLayer.Dtos.SystemUsers;
using SchoolBusWebApi.Interface;
using SchoolBusWebApi.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Repositories
{
    public class SystemUserRepository : BaseReprository, ISystemUserRepository
    {
        private readonly ITokenService _tokenService;

        public SystemUserRepository(ApplicationDbContext context, IMapper mapper, ITokenService tokenService) : base(context, mapper)
        {
            _tokenService = tokenService;
        }

        public async Task<int> Add(SystemUserDto item)
        {
            var Data = _mapper.Map<SystemUser>(item);
            Data.CreateTime = DateTime.Now;
            Data.CreatedBy = item.CreatedBy;
            _context.SystemUsers.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public bool CheckPassword(SystemUser user,string Password)
        {
            using var Hmac = new HMACSHA512(user.PasswordSalt);

            var ComputedHash = Hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));

            for (int i = 0; i < ComputedHash.Length; i++)
                if (ComputedHash[i] != user.PasswordHash[i])
                    return false;
            return true;
        }

        public void Delete(int id)
        {
            _context.SystemUsers.Remove(new SystemUser() { Id = id });
        }

        public async Task<List<SystemUserDto>> GetAsync()
        {
            var query = _context.SysRoles.AsQueryable();

            return await query.ProjectTo<SystemUserDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<SystemUserDto> Login(LoginDto loginDto)
        {
            var result = new SystemUserDto { Id = -1 };

            var user = await _context.SystemUsers.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());

            if (user == null)
                return result;



            if (!CheckPassword(user, loginDto.Password))
                result.Id = -2;

            result = new SystemUserDto
            {
                Id = user.Id,
                Full_Name = user.Full_Name,
                UserName = user.UserName,
                ImagePath = user.ImagePath,
                Token = _tokenService.CreateToken(user)
            };

            return result;
        }

        public async Task<bool> Update(SystemUserDto item)
        {
            var Data = await _context.SystemUsers.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> UserExists(string username)
        {
            return _context.SystemUsers.AnyAsync(r => r.UserName == username);
        }

        public async Task<List<SystemUserListDto>> GetListAsync()
        {
            var query = _context.SystemUsers.AsQueryable();

            return await query.ProjectTo<SystemUserListDto>(_mapper.ConfigurationProvider).ToListAsync();
        }


        public async Task<SystemUserDto> GetByIdAsync(int Id)
        {
            var query = _context.SystemUsers.Where(r => r.Id == Id).AsQueryable();

            return await query.ProjectTo<SystemUserDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<int> Add(CreateUserDto systemUser)
        {
            var data = await _context.SystemUsers.Where(r => r.UserName == systemUser.UserName).FirstOrDefaultAsync();
            if (data != null)
                return data.Id;

            using var hamc = new HMACSHA512();
            var item = new SystemUser()
            {
                PasswordHash = hamc.ComputeHash(Encoding.UTF8.GetBytes(systemUser.Password)),
                PasswordSalt = hamc.Key
            };
            _mapper.Map(systemUser, item);
            _context.SystemUsers.Add(item);
            await _context.SaveChangesAsync();
            return item.Id;
        }

        public async Task<bool> Update(CreateUserDto systemUser)
        {
            var Data = await _context.SystemUsers.FindAsync(systemUser.Id);
            _mapper.Map(systemUser, Data);
            using var hamc = new HMACSHA512();
            Data.PasswordHash = hamc.ComputeHash(Encoding.UTF8.GetBytes(systemUser.Password));
            Data.PasswordSalt = hamc.Key;
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
