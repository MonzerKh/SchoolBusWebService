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
    public class ComplaintController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public ComplaintController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetComplaint")]
        public async Task<ActionResult<PagedList<ComplaintDto>>> GetComplaints()
        {
            var Result = await businessUnit.Complaints.GetAsync();
            return Ok(Result);
        }

        [HttpGet("GetComplaintPaging")]
        public async Task<ActionResult<PagedList<ComplaintDto>>> Get([FromQuery] ComplaintParams ComplaintParams)
        {
            var reslut = await businessUnit.Complaints.GetByParamAsync(ComplaintParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("SetComplaint")]
        public async Task<ActionResult<ComplaintDto>> SetComplaint(ComplaintDto Complaint)
        {
            if (Complaint.Id == 0)
            {
                Complaint.CreatedBy = User.GetUserId();
                Complaint.Id = await businessUnit.Complaints.Add(Complaint);
                return Ok(Complaint);
            }
            else
            {
                Complaint.UpdateBy = User.GetUserId();
                if (await businessUnit.Complaints.Update(Complaint))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<Complaint>/5
        [HttpDelete("DelComplaint/{id}")]
        public async Task<ActionResult> DeleteComplaint(int id)
        {
            businessUnit.Complaints.Delete(id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }
    }
}
