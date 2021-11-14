using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using SchoolBusWebApi.Controllers.Core;
using SchoolBusWebApi.Extensions;
using SchoolBusWebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Controllers.Business
{
    [Authorize]
    public class SupervisorController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public SupervisorController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetSupervisor")]
        public async Task<ActionResult<PagedList<SupervisorDto>>> GetSupervisors()
        {
            var Result = await businessUnit.Supervisors.GetAsync();
            return Ok(Result);
        }

        [HttpGet("GetSupervisorPaging")]
        public async Task<ActionResult<PagedList<SupervisorDto>>> Get([FromQuery] SupervisorParams SupervisorParams)
        {
            var reslut = await businessUnit.Supervisors.GetByParamAsync(SupervisorParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("SetSupervisor")]
        public async Task<ActionResult<SupervisorDto>> SetSupervisor(SupervisorDto Supervisor)
        {
            if (Supervisor.Id == 0)
            {
                Supervisor.CreatedBy = User.GetUserId();
                Supervisor.Id = await businessUnit.Supervisors.Add(Supervisor);
                return Ok(Supervisor);
            }
            else
            {
                Supervisor.UpdateBy = User.GetUserId();
                if (await businessUnit.Supervisors.Update(Supervisor))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<Supervisor>/5
        [HttpDelete("DelSupervisor/{id}")]
        public async Task<ActionResult> DeleteSupervisor(int id)
        {
            businessUnit.Supervisors.Delete(id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }
    }
}
