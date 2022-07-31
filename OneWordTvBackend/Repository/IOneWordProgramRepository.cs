using OneWordTvBackend.Models;
using OneWordTvBackend.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WalletPlusIncAPI.Data.DataAccess.Interfaces
{
    
    public interface IOneWordProgramRepository : IGenericRepository<OneWordTvProgram>
    {
        Task<List<OneWordTvProgram>> GetMyOneWordTvProgramsByDay(string day);

    }
}