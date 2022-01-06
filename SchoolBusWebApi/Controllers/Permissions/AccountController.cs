using AutoMapper;
using DataAccessLayer.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables.Permissions;
using ModelsLayer.Dtos;
using ModelsLayer.Dtos.SystemUsers;
using SchoolBusWebApi.Interface;
using SchoolBusWebApi.Controllers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Dtos.DropList;
using SchoolBusWebApi.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace SchoolBusWebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUnitOfWork _userUnit;

        public AccountController(IUnitOfWork userUnit) { _userUnit = userUnit; }

        [HttpPost("login")]
        public async Task<ActionResult<SystemUserDto>> Login(LoginDto loginDto)
        {
            var user = await _userUnit.Users.Login(loginDto);

            switch (user.Id)
            {
                case -1:
                    return Unauthorized("Invalid User Name ...!");
                case -2:
                    return Unauthorized("Invalid Password ...!");
                default:
                    break;
            }

            return Ok(user);
        }

        [HttpPost("SetSystemUser")]
        public async Task<ActionResult<SystemUserDto>> SetSystemUser(CreateUserDto SystemUser)
        {
            if (SystemUser.Id == 0)
            {
                SystemUser.CreatedBy = User.GetUserId();
                SystemUser.Id = await _userUnit.Users.Add(SystemUser);
                var Result = await _userUnit.Users.GetByIdAsync(SystemUser.Id);
                return Ok(Result);
            }
            else
            {
                SystemUser.UpdateBy = User.GetUserId();
                if (await _userUnit.Users.Update(SystemUser))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }

        [HttpGet("UserExists")]
        public async Task<bool> UserExists(string username)
        {
            return await _userUnit.Users.UserExists(username);
        }



        [HttpGet("GetSystemUserList")]
        [Authorize]
        public async Task<ActionResult<SystemUserListDto>> GetSystemUserList()
        {
            var Result = await _userUnit.Users.GetListAsync();
            return Ok(Result);
        }

        [Authorize]
        [HttpGet("GetSystemUser/{id}")]
        public async Task<ActionResult<SystemUserDto>> GetSystemUserById(int Id)
        {
            var Result = await _userUnit.Users.GetByIdAsync(Id);
            return Ok(Result);
        }
    }
}
