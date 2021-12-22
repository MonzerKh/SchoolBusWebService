﻿using AutoMapper;
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
    public class StudentRepository : BaseReprository,IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper) { }


        public async Task<int> Add(StudentDto item)
        {
            var Data = _mapper.Map<Student>(item);
            Data.CreateTime = DateTime.Now;
            _context.Students.Add(Data);
            await _context.SaveChangesAsync();
            return Data.Id;
        }

        public void Delete(int id)
        {
            _context.Students.Remove(new Student() { Id = id });
        }

        public async Task<bool> Update(StudentDto item)
        {
            var Data = await _context.Students.FindAsync(item.Id);
            _mapper.Map(item, Data);
            Data.UpdateTime = DateTime.Now;
            _context.Entry(Data).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<StudentDto>> GetAsync()
        {
            var query = _context.Students.AsQueryable();

            return await query.ProjectTo<StudentDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<PagedList<StudentDto>> GetByParamAsync(StudentParams Param)
        {
            var query = _context.Students.ProjectTo<StudentDto>(_mapper
             .ConfigurationProvider).AsQueryable().AsNoTracking();

            if (!string.IsNullOrEmpty(Param.Full_Name))
                query = query.Where(r => r.Full_Name.Contains(Param.Full_Name));

            //if (!string.IsNullOrEmpty(Param.Manager))
            //    query = query.Where(r => r.Manager.Contains(Param.Manager));
            //if (Param.Address != null)
            //    query = query.Where(r => r.Address.Contains(Param.Address));

            if (Param.OrderBy =="Full_Name")
            {
                query = query.OrderBy(r => r.Full_Name);
            }

            return await PagedList<StudentDto>.CreateAsync(query,
                 Param.PageNumber, Param.PageSize);
        }
    }
}
