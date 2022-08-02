using OneWordTvBackend.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneWordTvBackend.Repository
{

    public interface IOneWordProgramRepository : IGenericRepository<OneWordTvProgram>
    {
        Task<List<OneWordTvProgram>> GetMyOneWordTvProgramsByDay(string day);

    }
}