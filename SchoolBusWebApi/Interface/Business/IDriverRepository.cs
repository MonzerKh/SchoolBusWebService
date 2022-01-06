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
    public interface IDriverRepository
    {

        Task<List<DriverDto>> GetAsync();

        Task<List<DriverListDto>> GetListAsync();
        Task<DriverDto> GetByIdAsync(int Id);
        Task<PagedList<DriverDto>> GetByParamAsync(DriverParams Param);
        Task<int> Add(DriverDto Driver);
        void Delete(int id);
        Task<bool> Update(DriverDto Driver);
    }
}
