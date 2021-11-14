using ModelsLayer.Dtos.Business;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface.Business
{
    public interface ISupervisorRepository
    {

        Task<List<SupervisorDto>> GetAsync();
        Task<PagedList<SupervisorDto>> GetByParamAsync(SupervisorParams Param);
        Task<int> Add(SupervisorDto Supervisor);
        void Delete(int id);
        Task<bool> Update(SupervisorDto Supervisor);
    }
}
