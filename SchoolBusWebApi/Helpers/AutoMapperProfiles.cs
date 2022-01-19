using AutoMapper;
using ModelsLayer.DataLayer.Tables;
using ModelsLayer.DataLayer.Tables.Permissions;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using ModelsLayer.Dtos.Permission;
using ModelsLayer.Dtos.SystemUsers;
using ModelsLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Helpers
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Bus, BusDto>()
                .ForMember(dest => dest.Company, opt => opt.MapFrom(r => r.BusCompany.Company));
            CreateMap<BusDto, Bus>();

            CreateMap<BusCompany, BusCompanyDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(r => r.SystemUser.UserName));
            CreateMap<BusCompanyDto, BusCompany>();
           
            CreateMap<Complaint, ComplaintDto>()
                .ForMember(dest => dest.School_Name, opt => opt.MapFrom(r => r.School.School_Name))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(r => r.BusCompany.Company));
            CreateMap<ComplaintDto, Complaint>();

            CreateMap<SysRole, RolesDto>();
            CreateMap<RolesDto, SysRole>();

            CreateMap<Driver_Bus, Driver_BusDto>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(r => r.Bus.Number))
                .ForMember(dest => dest.Marka, opt => opt.MapFrom(r => r.Bus.Marka))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(r => r.Bus.Capacity))
                .ForMember(dest => dest.Full_Name, opt => opt.MapFrom(r => r.Driver.Full_Name))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(r => r.Driver.Phone))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(r => r.Driver.ImagePath));
            CreateMap<Driver_BusDto, Driver_Bus>();

            CreateMap<Driver, DriverDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(r => r.SystemUser.UserName))
                .ForMember(dest => dest.Company, opt => opt.MapFrom(r => r.BusCompany.Company));
            CreateMap<DriverDto, Driver>();

            CreateMap<Guardian, GuardianDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(r => r.SystemUser.UserName))
                .ForMember(dest => dest.School_Name, opt => opt.MapFrom(r => r.School.School_Name));
            CreateMap<GuardianDto, Guardian>();


            CreateMap<Student, StudentDto>()
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(r => r.SystemUser.UserName))
              .ForMember(dest => dest.School_Name, opt => opt.MapFrom(r => r.School.School_Name))
              .ForMember(dest => dest.Guardian_Name, opt => opt.MapFrom(r => r.Guardian.Full_Name));
            CreateMap<StudentDto, Student>();


            CreateMap<Student, CreateStudentDto>()
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(r => r.SystemUser.UserName))
              .ForMember(dest => dest.School_Name, opt => opt.MapFrom(r => r.School.School_Name))
              .ForMember(dest => dest.Guardian_Name, opt => opt.MapFrom(r => r.Guardian.Full_Name));
            CreateMap<CreateStudentDto, Student>();


            CreateMap<Supervisor, SupervisorDto>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(r => r.SystemUser.UserName))
               .ForMember(dest => dest.School_Name, opt => opt.MapFrom(r => r.School.School_Name));
            CreateMap<SupervisorDto, Supervisor>();

            CreateMap<School, SchoolDto>()
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(r => r.CreateUser.UserName));
            CreateMap<SchoolDto, School>();

            CreateMap<School, SchoolListDto>();
            CreateMap<Guardian, GuardianListDto>();
            CreateMap<Driver, DriverListDto>();
            CreateMap<Student, StudentListDto>().IncludeAllDerived()
                 .ForMember(dest => dest.Full_Address, opt => opt.MapFrom(r => r.Country+" "+r.Address))
                 .ForMember(dest => dest.School_Id, opt => opt.MapFrom(r => r.School.Id))
                 .ForMember(dest => dest.School_Name, opt => opt.MapFrom(r => r.School.School_Name))
                 .ForMember(dest => dest.Bus_Id, opt => opt.MapFrom(r => r.Student_Buses.Where(r=>r.IsActive==true).FirstOrDefault().Bus_Id ))
                 .ForMember(dest => dest.Company, opt => opt.MapFrom(r => r.Student_Buses.Where(r => r.IsActive == true).FirstOrDefault().Bus.BusCompany.Company))
                 .ForMember(dest => dest.Bus_Name, opt => opt.MapFrom(r => r.Student_Buses.Where(r => r.IsActive == true).FirstOrDefault().Bus.Number));

            CreateMap<Supervisor, SupervisorListDto>();
            CreateMap<SystemUser, SystemUserListDto>();
            CreateMap<SystemUserDto, SystemUser>();
            CreateMap<SystemUser, SystemUserDto>();
            CreateMap<CreateUserDto, SystemUser>();
            CreateMap<SystemUser, CreateUserDto>();
            CreateMap<BusCompany, BusCompanyListDto>();
            
            CreateMap<Student_Bus, Student_BusDto>()
                .ForMember(dest => dest.Marka,opt=>opt.MapFrom(r=>r.Bus.Marka))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(r => r.Bus.Capacity))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(r => r.Bus.Number))
                .ForMember(dest => dest.Full_Name, opt => opt.MapFrom(r => r.Student.Full_Name))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(r => r.Student.Phone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(r => r.Student.Email));
            CreateMap<Student_BusDto, Student_Bus>();
            CreateMap<Student_Bus, StudentBusListDto>()
                 .ForMember(dest => dest.Student_Full_Name, opt => opt.MapFrom(r => r.Student.Full_Name))
                 .ForMember(dest => dest.Bus_Marka_Number, opt => opt.MapFrom(r => string.Format("{0} - {1}", r.Bus.Marka , r.Bus.Number)));



            CreateMap<Student_Bus, LocationPeer>()
                 .ForMember(dest => dest.lat, opt => opt.MapFrom(r => r.Student.lat))
                 .ForMember(dest => dest.lng, opt => opt.MapFrom(r => r.Student.lng))
                 .ForMember(dest => dest.Phone, opt => opt.MapFrom(r => r.Student.Phone))
                 .ForMember(dest => dest.Full_Name, opt => opt.MapFrom(r => r.Student.Full_Name));

            CreateMap<School, LocationPeer>()
                .ForMember(dest => dest.Full_Name, opt => opt.MapFrom(r => r.School_Name));


        }
    }
}
