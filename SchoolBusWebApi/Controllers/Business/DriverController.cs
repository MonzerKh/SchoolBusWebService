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
    public class DriverController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public DriverController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetDriver")]
        public async Task<ActionResult<PagedList<DriverDto>>> GetDrivers()
        {
            var Result = await businessUnit.Drivers.GetAsync();
            return Ok(Result);
        }

        [HttpGet("GetDriverList")]
        public async Task<ActionResult<PagedList<DriverListDto>>> GetDriverList()
        {
            var Result = await businessUnit.Drivers.GetListAsync();
            return Ok(Result);
        }

        [HttpGet("GetDriver/{id}")]
        public async Task<ActionResult<DriverDto>> GetDriverById(int Id)
        {
            var Result = await businessUnit.Drivers.GetByIdAsync(Id);
            return Ok(Result);
        }


        [HttpGet("GetDriverPaging")]
        public async Task<ActionResult<PagedList<DriverDto>>> Get([FromQuery] DriverParams DriverParams)
        {
            var reslut = await businessUnit.Drivers.GetByParamAsync(DriverParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("SetDriver")]
        public async Task<ActionResult<DriverDto>> SetDriver(DriverDto Driver)
        {
            if (Driver.Id == 0)
            {
                Driver.CreatedBy = User.GetUserId();
                Driver.Id = await businessUnit.Drivers.Add(Driver);
                return Ok(Driver);
            }
            else
            {
                Driver.UpdateBy = User.GetUserId();
                if (await businessUnit.Drivers.Update(Driver))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<Driver>/5
        [HttpDelete("DelDriver/{id}")]
        public async Task<ActionResult> DeleteDriver(int id)
        {
            businessUnit.Drivers.Delete(id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }
    }
}
