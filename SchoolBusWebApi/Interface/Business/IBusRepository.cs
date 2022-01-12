using ModelsLayer.Dtos.Business;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface.Business
{
    public interface IBusRepository
    {

        Task<List<BusDto>> GetAsync(int BusCompany_Id);

        Task<BusDto> GetByIdAsync(int Id);
        Task<PagedList<BusDto>> GetByParamAsync(BusParams Param);
        Task<int> Add(BusDto Bus);
        void Delete(int id);
        Task<bool> Update(BusDto Bus);
    }
}
