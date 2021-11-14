using ModelsLayer.Dtos.Business;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface.Business
{
    public interface IBusCompanyRepository
    {

        Task<List<BusCompanyDto>> GetAsync();
        Task<PagedList<BusCompanyDto>> GetByParamAsync(BusCompanyParams Param);
        Task<int> Add(BusCompanyDto BusCompany);
        void Delete(int id);
        Task<bool> Update(BusCompanyDto BusCompany);
    }
}
