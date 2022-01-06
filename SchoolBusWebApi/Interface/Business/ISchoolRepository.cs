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
    public interface ISchoolRepository
    {

        Task<List<SchoolDto>> GetAsync();
        Task<List<SchoolListDto>> GetListAsync();
        Task<SchoolDto> GetByIdAsync(int Id);
        Task<PagedList<SchoolDto>> GetByParamAsync(SchoolParams Param);
        Task<int> Add(SchoolDto School);
        void Delete(int id);
        Task<bool> Update(SchoolDto School);
    }
}
