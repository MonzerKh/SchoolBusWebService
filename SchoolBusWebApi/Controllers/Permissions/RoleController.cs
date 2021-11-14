using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Dtos.Permission;
using ModelsLayer.Helper;
using SchoolBusWebApi.Interface;
using ModelsLayer.Params;
using SchoolBusWebApi.Controllers.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SchoolBusWebApi.Extensions;

namespace SchoolBusWebApi.Controllers.Permissions
{
    [Authorize]
    public class RoleController : BaseApiController
    {
        private IUnitOfWork _userUnit;

        public RoleController(IUnitOfWork userUnit) { _userUnit = userUnit; }
       
        [HttpGet("GetAll")]
        public async Task<ActionResult<PagedList<RolesDto>>> GetRoles()
        {
            var Result = await _userUnit.Roles.GetAsync();
            return Ok(Result);
        }

        [HttpGet("GetPaging")]
        public async Task<ActionResult<PagedList<RolesDto>>> Get([FromQuery] RoleParams roleParams)
        {
            var reslut =  await _userUnit.Roles.GetByParamAsync(roleParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("Set")]
        public async Task<ActionResult<RolesDto>> SetRole(RolesDto role)
        {
            if (role.Id == 0)
            {
                role.Id = await _userUnit.Roles.Add(role);
                return Ok(role);
            }
            else
            {
                if (await _userUnit.Roles.Update(role))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<School>/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            _userUnit.Roles.Delete(id);
            if (await _userUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }

    }
}
