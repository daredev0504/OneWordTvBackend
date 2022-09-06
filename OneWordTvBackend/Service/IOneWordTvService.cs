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
        //Task<ResponseMessage<List<OneWordProgramTvUpdateDTO>>> GetMyOneWordTvProgramsByDay(string day);
        Task<ResponseMessage<List<OneWordProgramTvUpdateDTO>>> GetAllOneWordTvPrograms();
        Task<ResponseMessage<string>> AddOneWordTvProgram(OneWordProgramTvCreateDTO model);
        Task<ResponseMessage<string>> UpdateOneWordTvProgram(OneWordProgramTvUpdateDTO model);
        Task<ResponseMessage<string>> DeleteProgram(string id);
    }
}
