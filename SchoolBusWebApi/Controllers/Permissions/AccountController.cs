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

namespace SchoolBusWebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IUnitOfWork _userUnit;

        public AccountController(IUnitOfWork userUnit) { _userUnit = userUnit; }

        [HttpPost("login")]
        public async Task<ActionResult<SystemUserDto>> Login(LoginDto loginDto)
        {
            var user = await _userUnit.User.Login(loginDto);

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

        [HttpGet("UserExists")]
        public async Task<bool> UserExists(string username)
        {
            return await _userUnit.User.UserExists(username);
        }


    }
}
