using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OneWordTvBackend.Data;
using OneWordTvBackend.Helpers;
using OneWordTvBackend.Models;

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

        public async Task<List<OneWordTvProgram>> GetMyOneWordTvProgramsByDay(string day)
        {
            var result = _context.OneWordTvPrograms.Where(x => x.Day == (DayConstants)Enum.Parse(typeof(DayConstants), day, true));
            return await result.ToListAsync();
        }
    }
}