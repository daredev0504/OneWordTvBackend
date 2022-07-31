using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OneWordTvBackend.Data;
using OneWordTvBackend.Models;
using WalletPlusIncAPI.Data.DataAccess.Interfaces;

namespace OneWordTvBackend.Repository
{

    public class OneWordProgramRepository : GenericRepository<OneWordTvProgram>, IOneWordProgramRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
      


        public OneWordProgramRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<List<OneWordTvProgram>> GetMyOneWordTvProgramsByDay(string day)
        {
            throw new NotImplementedException();
        }
    }
}