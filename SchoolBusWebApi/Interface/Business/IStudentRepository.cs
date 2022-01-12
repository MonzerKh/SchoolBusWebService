using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface.Business
{
    public interface IStudentRepository
    {

        Task<List<StudentDto>> GetAsync();
        Task<StudentDto> GetByIdAsync(int Id);
        Task<string> GetImageByIdAsync(int Id);
        Task<List<StudentListDto>> GetListAsync(int School_Id);
        Task<PagedList<StudentDto>> GetByParamAsync(StudentParams Param);
        Task<int> Add(CreateStudentDto Student);
        void Delete(int id);
        Task<bool> Update(CreateStudentDto Student);
    }
}
