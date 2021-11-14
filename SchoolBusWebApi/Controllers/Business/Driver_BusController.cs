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
    public class Driver_BusController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public Driver_BusController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetDriver_Bus")]
        public async Task<ActionResult<PagedList<Driver_BusDto>>> GetDriver_Buses()
        {
            var Result = await businessUnit.Driver_Buses.GetAsync();
            return Ok(Result);
        }

        [HttpGet("GetDriver_BusPaging")]
        public async Task<ActionResult<PagedList<Driver_BusDto>>> Get([FromQuery] Driver_BusParams Driver_BusParams)
        {
            var reslut = await businessUnit.Driver_Buses.GetByParamAsync(Driver_BusParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("SetDriver_Bus")]
        public async Task<ActionResult<Driver_BusDto>> SetDriver_Bus(Driver_BusDto Driver_Bus)
        {
            if (Driver_Bus.Id == 0)
            {
                Driver_Bus.CreatedBy = User.GetUserId();
                await businessUnit.Driver_Buses.Add(Driver_Bus);
                return Ok(Driver_Bus);
            }
            else
            {
                Driver_Bus.UpdateBy = User.GetUserId();
                if (await businessUnit.Driver_Buses.Update(Driver_Bus))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<Driver_Bus>/5
        [HttpDelete("DelDriver_Bus/{id}")]
        public async Task<ActionResult> DeleteDriver_Bus(int bus_Id, int driver_Id)
        {
            businessUnit.Driver_Buses.Delete( bus_Id,  driver_Id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }
    }
}
