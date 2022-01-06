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
    public class BusController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public BusController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetBus")]
        public async Task<ActionResult<PagedList<BusDto>>> GetBuses()
        {
            var Result = await businessUnit.Buses.GetAsync();
            return Ok(Result);
        }

        [HttpGet("GetBus/{id}")]
        public async Task<ActionResult<BusDto>> GetBusById(int Id)
        {
            var Result = await businessUnit.Buses.GetByIdAsync(Id);
            return Ok(Result);
        }


        [HttpGet("GetBusPaging")]
        public async Task<ActionResult<PagedList<BusDto>>> Get([FromQuery] BusParams BusParams)
        {
            var reslut = await businessUnit.Buses.GetByParamAsync(BusParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("SetBus")]
        public async Task<ActionResult<BusDto>> SetBus(BusDto Bus)
        {
            if (Bus.Id == 0)
            {
                Bus.CreatedBy = User.GetUserId();
                Bus.Id = await businessUnit.Buses.Add(Bus);
                return Ok(Bus);
            }
            else
            {
                Bus.UpdateBy = User.GetUserId();
                if (await businessUnit.Buses.Update(Bus))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<Bus>/5
        [HttpDelete("DelBus/{id}")]
        public async Task<ActionResult> DeleteBus(int id)
        {
            businessUnit.Buses.Delete(id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }
    }
}
