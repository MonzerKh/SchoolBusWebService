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
    public class SchoolController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public SchoolController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetSchool")]
        public async Task<ActionResult<PagedList<SchoolDto>>> GetSchools()
        {
            var Result = await businessUnit.Schools.GetAsync();
            return Ok(Result);
        }

        [HttpGet("GetSchool/{id}")]
        public async Task<ActionResult<SchoolDto>> GetSchoolById(int Id)
        {
            var Result = await businessUnit.Schools.GetByIdAsync(Id);
            return Ok(Result);
        }

        [HttpGet("GetSchoolPaging")]
        public async Task<ActionResult<PagedList<SchoolDto>>> Get([FromQuery] SchoolParams SchoolParams)
        {
            var reslut = await businessUnit.Schools.GetByParamAsync(SchoolParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("SetSchool")]
        public async Task<ActionResult<SchoolDto>> SetSchool(SchoolDto School)
        {
            if (School.Id == 0)
            {
                School.CreatedBy = User.GetUserId();
                School.Id = await businessUnit.Schools.Add(School);
                return Ok(School);
            }
            else
            {
                School.UpdateBy = User.GetUserId();
                if (await businessUnit.Schools.Update(School))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<School>/5
        [HttpDelete("DelSchool/{id}")]
        public async Task<ActionResult> DeleteSchool(int id)
        {
            businessUnit.Schools.Delete(id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }
    }
}
