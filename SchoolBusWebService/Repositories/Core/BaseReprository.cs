using AutoMapper;
using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebService.Repositories.Core
{
    public class BaseReprository
    {
        protected private readonly ApplicationDbContext _context;
        protected private readonly IMapper _mapper;

        public BaseReprository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}
