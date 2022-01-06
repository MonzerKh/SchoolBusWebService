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
    public class BusCompanyController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public BusCompanyController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetBusCompany")]
        public async Task<ActionResult<PagedList<BusCompanyDto>>> GetBusCompanies()
        {
            var Result = await businessUnit.BusCompanies.GetAsync();
            return Ok(Result);
        }

        [HttpGet("GetBusCompanyPaging")]
        public async Task<ActionResult<PagedList<BusCompanyDto>>> Get([FromQuery] BusCompanyParams BusCompanyParams)
        {
            var reslut = await businessUnit.BusCompanies.GetByParamAsync(BusCompanyParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpGet("GetBusCompanyList")]
        public async Task<ActionResult<BusCompanyListDto>> GetBusCompanyList()
        {
            var Result = await businessUnit.BusCompanies.GetListAsync();
            return Ok(Result);
        }


        [HttpGet("GetBusCompany/{id}")]
        public async Task<ActionResult<BusCompanyDto>> GetBusCompanyById(int Id)
        {
            var Result = await businessUnit.BusCompanies.GetByIdAsync(Id);
            return Ok(Result);
        }

        [HttpPost("SetBusCompany")]
        public async Task<ActionResult<BusCompanyDto>> SetBusCompany(BusCompanyDto BusCompany)
        {
            if (BusCompany.Id ==0)
            {
                BusCompany.CreatedBy = User.GetUserId();
                BusCompany.Id = await businessUnit.BusCompanies.Add(BusCompany);
                return Ok(BusCompany);
            }
            else
            {
                BusCompany.UpdateBy = User.GetUserId();
                if (await businessUnit.BusCompanies.Update(BusCompany))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<BusCompany>/5
        [HttpDelete("DelBusCompany/{id}")]
        public async Task<ActionResult> DeleteBusCompany(int id)
        {
            businessUnit.BusCompanies.Delete(id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }
    }
}
