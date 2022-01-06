using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccessLayer.DataAccess;
using Microsoft.EntityFrameworkCore;
using ModelsLayer.DataLayer.Tables;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using ModelsLayer.Helper;
using ModelsLayer.Params;
using SchoolBusWebApi.Helpers;
using SchoolBusWebApi.Interface.Business;
using SchoolBusWebApi.Repositories.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Repositories.Business
{
    public class SchoolRepository : BaseReprository,ISchoolRepository
    {
        public SchoolRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<int> Add(SchoolDto item)
        {
            var Data = _mapper.Map<School>(item);
            //bool ImageStatus = !string.IsNullOrEmpty(item.LogoImage);
            //if (ImageStatus)
            //    Data.Logo = SystemConfigurations.FromBase64String(item.LogoImage);
          
            Data.CreateTime = DateTime.Now;
            Data.CreateUser_Id = item.CreatedBy;
            _context.Schools.Add(Data);
            await _context.SaveChangesAsync();
            //if (ImageStatus)
            //{
            //    try
            //    {
            //        string Root = Path.GetFullPath(@"./" + string.Format("/assets/images/Schools/School_{0}.png", Data.Id));
            //        await File.WriteAllBytesAsync(Root, Data.Logo);
            //        Data.SchoolUrl = Root;
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (Exception ex)
            //    {
            //        string err = ex.Message;
            //    }

            //}
            return Data.Id;
        }

        public void Delete(int id)
        {
            _context.Schools.Remove(new School() { Id = id });
        }

        public async Task<bool> Update(SchoolDto item)
        {
            var Data = await _context.Schools.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<SchoolDto>> GetAsync()
        {
            var query = _context.Schools.AsQueryable();

            return await query.ProjectTo<SchoolDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<SchoolListDto>> GetListAsync()
        {
            var query = _context.Schools.AsQueryable();

            return await query.ProjectTo<SchoolListDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<SchoolDto> GetByIdAsync(int Id)
        {
            var query = _context.Schools.Where(r=>r.Id == Id).AsQueryable();

            return await query.ProjectTo<SchoolDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<PagedList<SchoolDto>> GetByParamAsync(SchoolParams Param)
        {
            var query = _context.Schools.ProjectTo<SchoolDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(Param.School_Name))
                query = query.Where(r => r.School_Name.Contains(Param.School_Name));

            if (!string.IsNullOrEmpty(Param.Manager))
                query = query.Where(r => r.Manager.Contains(Param.Manager));
            if (Param.Address != null)
                query = query.Where(r => r.Address.Contains(Param.Address));

            return await PagedList<SchoolDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
