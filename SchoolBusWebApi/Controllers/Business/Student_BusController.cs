using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using ModelsLayer.Helper;
using ModelsLayer.Models;
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
    public class Student_BusController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public Student_BusController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetStudentBus")]
        public async Task<ActionResult<PagedList<Student_BusDto>>> GetStudent_Buss([FromQuery] StudentBusParams Params)
        {
            var Result = await businessUnit.Student_Buses.GetAsync(Params);
            return Ok(Result);
        }

        [HttpGet("GetStudentBusList")]
        public async Task<ActionResult<PagedList<StudentBusListDto>>> GetStudent_BusList([FromQuery] StudentBusParams Params)
        {
            var Result = await businessUnit.Student_Buses.GetListAsync(Params);
            return Ok(Result);
        }



        [HttpGet("GetStudentBus/{id}")]
        public async Task<ActionResult<StudentBusListDto>> GetStudent_BusById(int Id)
        {
            var Result = await businessUnit.Student_Buses.GetByIdAsync(Id);
            return Ok(Result);
        }

        [HttpGet("GetStudentBusPaging")]
        public async Task<ActionResult<PagedList<Student_BusDto>>> GetPagingAsync([FromQuery] StudentBusParams Params)
        {
            var reslut = await businessUnit.Student_Buses.GetPagingAsync(Params);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("SetStudentBus")]
        public async Task<ActionResult<Student_BusDto>> SetStudent_Bus(Student_BusDto Student_Bus)
        {
            if (Student_Bus.Id == 0)
            {
                Student_Bus.CreatedBy = User.GetUserId();
                Student_Bus.Id = await businessUnit.Student_Buses.Add(Student_Bus);
                return Ok(Student_Bus);
            }
            else
            {
                Student_Bus.UpdateBy = User.GetUserId();
                if (await businessUnit.Student_Buses.Update(Student_Bus))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }

        [HttpPost("SetBulkStudentBus")]
        public async Task<ActionResult> SetBulkStudentBus(BulkStudentBus BulkStudent)
        {
            bool status = await businessUnit.SetBulkStudentBus(BulkStudent.students, BulkStudent.bus, User.GetUserId());
            if (status)
                return Ok();

            return BadRequest("Error While Insert Data ..!");
        }

        // DELETE api/<Student_Bus>/5
        [HttpDelete("DelStudentBus/{id}")]
        public async Task<ActionResult> DeleteStudent_Bus(int id)
        {
            businessUnit.Student_Buses.Delete(id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }

        [HttpGet("GetStudentBusTSP")]
        public async Task<ActionResult<List<StudentPeer>>> GetStudentBusTSP([FromQuery] StudentBusParams Params)
        {
            var reslut = await businessUnit.Student_Buses.GetStudentBusTSP(Params);

            return Ok(reslut);
        }

    }
}
