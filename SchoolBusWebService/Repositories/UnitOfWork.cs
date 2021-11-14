using AutoMapper;
using DataAccessLayer.DataAccess;
using ModelsLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolBusWebService.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context, IMapper mapper, ITokenService tokenService)
        {
            _context = context;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public ISystemUserRepository User => new SystemUserRepository(_context, _mapper, _tokenService);

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
