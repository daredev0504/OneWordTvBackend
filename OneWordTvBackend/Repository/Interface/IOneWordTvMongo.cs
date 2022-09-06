using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using OneWordTvBackend.Models;
using OneWordTvBackend.Models.Dto;

namespace OneWordTvBackend.Repository.Interface
{
    public interface IOneWordTvMongo
    {
        Task<OneWordTvProgram> AddProgram(OneWordTvProgram program);
        Task<ReplaceOneResult> UpdateProgram(string id, OneWordTvProgram program);
        Task<DeleteResult> DeleteProgram(string id);
        Task<OneWordTvProgram> GetProgramById(string id);
        Task<List<OneWordTvProgram>> GetAllPrograms();
        Task<List<OneWordTvProgram>> GetMyOneWordTvProgramsByDay(string day);
    }
}
