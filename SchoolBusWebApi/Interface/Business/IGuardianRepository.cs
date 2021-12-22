using ModelsLayer.Dtos.Business;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface.Business
{
    public interface IGuardianRepository
    {

        Task<List<GuardianDto>> GetAsync();
        Task<GuardianDto> GetByIdAsync(int Id);
        Task<PagedList<GuardianDto>> GetByParamAsync(GuardianParams Param);
        Task<int> Add(GuardianDto Guardian);
        void Delete(int id);
        Task<bool> Update(GuardianDto Guardian);
    }
}
