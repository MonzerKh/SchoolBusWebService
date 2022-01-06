using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
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
    public class GuardianController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public GuardianController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetGuardian")]
        public async Task<ActionResult<PagedList<GuardianDto>>> GetGuardians()
        {
            var Result = await businessUnit.Guardians.GetAsync();
            return Ok(Result);
        }
        [HttpGet("GetGuardianList")]
        public async Task<ActionResult<PagedList<GuardianListDto>>> GetGuardianList()
        {
            var Result = await businessUnit.Guardians.GetListAsync();
            return Ok(Result);
        }

        [HttpGet("GetGuardian/{id}")]
        public async Task<ActionResult<GuardianDto>> GetGuardianById(int Id)
        {
            var Result = await businessUnit.Guardians.GetByIdAsync(Id);
            return Ok(Result);
        }

        [HttpGet("GetGuardianPaging")]
        public async Task<ActionResult<PagedList<GuardianDto>>> Get([FromQuery] GuardianParams GuardianParams)
        {
            var reslut = await businessUnit.Guardians.GetByParamAsync(GuardianParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("SetGuardian")]
        public async Task<ActionResult<GuardianDto>> SetGuardian(GuardianDto Guardian)
        {
            if (Guardian.Id == 0)
            {
                Guardian.CreatedBy = User.GetUserId();
                Guardian.Id = await businessUnit.Guardians.Add(Guardian);
                return Ok(Guardian);
            }
            else
            {
                Guardian.UpdateBy = User.GetUserId();
                if (await businessUnit.Guardians.Update(Guardian))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<Guardian>/5
        [HttpDelete("DelGuardian/{id}")]
        public async Task<ActionResult> DeleteGuardian(int id)
        {
            businessUnit.Guardians.Delete(id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }
    }
}
