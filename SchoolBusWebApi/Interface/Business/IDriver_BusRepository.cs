using ModelsLayer.Dtos.Business;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface.Business
{
    public interface IDriver_BusRepository
    {

        Task<List<Driver_BusDto>> GetAsync();
        Task<PagedList<Driver_BusDto>> GetByParamAsync(Driver_BusParams Param);
        Task Add(Driver_BusDto Driver_Bus);
        void Delete(int bus_Id, int driver_Id);
        Task<bool> Update(Driver_BusDto Driver_Bus);
    }
}
