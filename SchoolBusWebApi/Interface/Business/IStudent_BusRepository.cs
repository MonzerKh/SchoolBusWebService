using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using ModelsLayer.Helper;
using ModelsLayer.Models;
using ModelsLayer.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface.Business
{
    public interface IStudent_BusRepository
    {
        Task<List<Student_BusDto>> GetAsync(StudentBusParams Params);
        Task<List<StudentBusListDto>> GetListAsync(StudentBusParams Params);
        Task<Student_BusDto> GetByIdAsync(int id);
        Task<PagedList<Student_BusDto>> GetPagingAsync(StudentBusParams Params);
        Task<int> Add(Student_BusDto student_Bus);
        Task<bool> Update(Student_BusDto student_Bus);
        void Delete(int id);
        void DeActivatedPerviousBus(int id,int user_Id);
        void AddAsync(Student_BusDto student_BusDto);
        Task<List<LocationPeer>> GetStudentBusTSP(StudentBusParams Params);
    }
}
