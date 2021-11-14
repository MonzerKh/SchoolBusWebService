using ModelsLayer.Dtos.Business;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface.Business
{
    public interface IComplaintRepository
    {

        Task<List<ComplaintDto>> GetAsync();
        Task<PagedList<ComplaintDto>> GetByParamAsync(ComplaintParams Param);
        Task<int> Add(ComplaintDto Complaint);
        void Delete(int id);
        Task<bool> Update(ComplaintDto Complaint);
    }
}
