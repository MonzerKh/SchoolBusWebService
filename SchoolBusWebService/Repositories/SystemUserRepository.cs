using AutoMapper;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables.Permissions;
using ModelsLayer.Dtos.SystemUsers;
using ModelsLayer.Interfaces;
using SchoolBusWebService.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWebService.Repositories
{
    public class SystemUserRepository : BaseReprository, ISystemUserRepository
    {
        private readonly ITokenService _tokenService;

        public SystemUserRepository(ApplicationDbContext context, IMapper mapper, ITokenService tokenService) : base(context, mapper)
        {
            _tokenService = tokenService;
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

        public Task<bool> UserExists(string username)
        {
            return _context.SystemUsers.AnyAsync(r => r.UserName == username);
        }
    }
}
