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
    public class StudentController : BaseApiController
    {
        private readonly IBusinessUnitOfWork businessUnit;

        public StudentController(IBusinessUnitOfWork businessUnit)
        {
            this.businessUnit = businessUnit;
        }

        [HttpGet("GetStudent")]
        public async Task<ActionResult<PagedList<StudentDto>>> GetStudents()
        {
            var Result = await businessUnit.Students.GetAsync();
            return Ok(Result);
        }

        [HttpGet("GetStudentList")]
        public async Task<ActionResult<PagedList<StudentListDto>>> GetStudentList(int School_Id = 0)
        {
            var Result = await businessUnit.Students.GetListAsync(School_Id);
            return Ok(Result);
        }



        [HttpGet("GetStudent/{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int Id)
        {
            var Result = await businessUnit.Students.GetByIdAsync(Id);
            return Ok(Result);
        }

        [HttpGet("GetStudentImage/{id}")]
        public async Task<ActionResult<ImageDto>> GetImageByIdAsync(int id)
        {
            var result = new ImageDto();
            result.Id = id;

            result.ImageData = await businessUnit.Students.GetImageByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("GetStudentPaging")]
        public async Task<ActionResult<PagedList<StudentDto>>> Get([FromQuery] StudentParams StudentParams)
        {
            var reslut = await businessUnit.Students.GetByParamAsync(StudentParams);

            Response.AddPaginationHeader(reslut.CurrentPage, reslut.PageSize,
              reslut.TotalCount, reslut.TotalPages);

            return Ok(reslut);
        }

        [HttpPost("SetStudent")]
        public async Task<ActionResult<CreateStudentDto>> SetStudent(CreateStudentDto Student)
        {
            if (Student.Id == 0)
            {
                Student.CreatedBy = User.GetUserId();
                Student.Id = await businessUnit.Students.Add(Student);
                return Ok(Student);
            }
            else
            {
                Student.UpdateBy = User.GetUserId();
                if (await businessUnit.Students.Update(Student))
                    return Ok();
            }
            return BadRequest("Error While Insert Data ..!");
        }


        // DELETE api/<Student>/5
        [HttpDelete("DelStudent/{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            businessUnit.Students.Delete(id);
            if (await businessUnit.Complete()) return Ok();

            return BadRequest("Error While Delete Data ..!");
        }
    }
}
