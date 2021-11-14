using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebService.Helpers
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<SystemUsers, MemberDto>()
            //    .ForMember(dest=>dest.PhotoUrl,opt=>opt.MapFrom(r=>r.Photos.Where(x=>x.IsMain).FirstOrDefault().Url));

            //CreateMap<Photo, PhotoDto>();

            //CreateMap<MemberUpdateDto, SystemUsers>();
        }
    }
}
