using OneWordTvBackend.Helpers;
using OneWordTvBackend.Models;
using OneWordTvBackend.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWordTvBackend.Service
{
    public interface IOneWordTvService
    {
        Task<List<OneWordTvProgram>> GetMyOneWordTvProgramsByDay(string day);
        List<OneWordTvProgram> GetAllOneWordTvPrograms();
        Task<ResponseMessage<string>> AddOneWordTvProgram(OneWordProgramTvDTO model);
        Task<ResponseMessage<string>> UpdateOneWordTvProgram(OneWordProgramTvDTO model);

    }
}
