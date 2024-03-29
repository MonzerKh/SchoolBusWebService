﻿using AutoMapper;
using DataAccessLayer.DataAccess;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using SchoolBusWebApi.Interface;
using SchoolBusWebApi.Interface.Business;
using SchoolBusWebApi.Repositories.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Repositories.Core
{
    public class BusinessUnitOfWork : IBusinessUnitOfWork
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public BusinessUnitOfWork(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ISchoolRepository Schools => new SchoolRepository(_context, _mapper);

        public IBusRepository Buses => new BusRepository(_context, _mapper);

        public IBusCompanyRepository BusCompanies => new BusCompanyRepository(_context, _mapper);

        public IComplaintRepository Complaints => new ComplaintRepository(_context, _mapper);

        public IDriver_BusRepository Driver_Buses => new Driver_BusRepository(_context, _mapper);

        public IDriverRepository Drivers => new DriverRepository(_context, _mapper);

        public IGuardianRepository Guardians => new GuardianRepository(_context, _mapper);

        public IStudentRepository Students => new StudentRepository(_context, _mapper);

        public ISupervisorRepository Supervisors => new SupervisorRepository(_context, _mapper);

        public IStudent_BusRepository Student_Buses => new Student_BusRepository(_context, _mapper);

        public async Task<bool> SetBulkStudentBus(List<StudentListDto> students, BusDto bus,int user_Id)
        {
            foreach (var student in students)
            {
                Student_Buses.DeActivatedPerviousBus(student.Id,user_Id);
                Student_Buses.AddAsync(new Student_BusDto { Student_Id = student.Id, Bus_Id = bus.Id, CreatedBy = user_Id });
            }
            return await Complete();
        }
        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }



    
        public bool HasChanges()
        {
            _context.ChangeTracker.DetectChanges();
            var changes = _context.ChangeTracker.HasChanges();
            return changes;
        }

        
    }
}
