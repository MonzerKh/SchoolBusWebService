using AutoMapper;
using ModelsLayer.DataLayer.Tables;
using ModelsLayer.DataLayer.Tables.Permissions;
using ModelsLayer.Dtos.Business;
using ModelsLayer.Dtos.DropList;
using ModelsLayer.Dtos.Permission;
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
        }
    }
}
