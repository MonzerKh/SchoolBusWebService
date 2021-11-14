using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using SchoolBusWebApi.Interface.Business;
using SchoolBusWebApi.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Repositories.Business
{
    public class ComplaintRepository : BaseReprository,IComplaintRepository
    {
        public ComplaintRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<int> Add(ComplaintDto item)
        {
            var Data = _mapper.Map<Complaint>(item);
            Data.CreateTime = DateTime.Now;
            _context.Complaints.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public void Delete(int id)
        {
            _context.Complaints.Remove(new Complaint() { Id = id });
        }

        public async Task<bool> Update(ComplaintDto item)
        {
            var Data = await _context.Complaints.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ComplaintDto>> GetAsync()
        {
            var query = _context.Complaints.AsQueryable();

            return await query.ProjectTo<ComplaintDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PagedList<ComplaintDto>> GetByParamAsync(ComplaintParams Param)
        {
            var query = _context.Complaints.ProjectTo<ComplaintDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            //if (!string.IsNullOrEmpty(Param.Complaint_Name))
            //    query = query.Where(r => r.Complaint_Name.Contains(Param.Complaint_Name));

            //if (!string.IsNullOrEmpty(Param.Manager))
            //    query = query.Where(r => r.Manager.Contains(Param.Manager));
            //if (Param.Address != null)
            //    query = query.Where(r => r.Address.Contains(Param.Address));

            return await PagedList<ComplaintDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
