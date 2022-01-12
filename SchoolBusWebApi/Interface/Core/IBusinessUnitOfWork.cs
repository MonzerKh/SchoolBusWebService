using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using SchoolBusWebApi.Interface.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface
{
    public interface IBusinessUnitOfWork
    {
        public IBusRepository Buses { get; }
        public IBusCompanyRepository BusCompanies { get; }
        public IComplaintRepository Complaints { get; }
        public IDriver_BusRepository Driver_Buses { get; }
        public IDriverRepository Drivers { get; }
        public IGuardianRepository Guardians { get; }
        public IStudentRepository Students { get; }
        public ISupervisorRepository Supervisors { get; }
        public ISchoolRepository Schools { get; }
        public IStudent_BusRepository Student_Buses { get; }

        Task<bool> Complete();
        bool HasChanges();
        Task<bool> SetBulkStudentBus(List<StudentListDto> students, BusDto bus,int User_Id);
    }
}
