using OneWordTvBackend.Helpers;
using OneWordTvBackend.Models;
using OneWordTvBackend.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletPlusIncAPI.Data.DataAccess.Interfaces;

namespace OneWordTvBackend.Service
{
    public class OneWordTvService : IOneWordTvService
    {
        private readonly IOneWordProgramRepository _oneWordProgramRepository;

        public OneWordTvService(IOneWordProgramRepository oneWordProgramRepository)
        {
            _oneWordProgramRepository = oneWordProgramRepository;
        }

        public async Task<ResponseMessage<string>> AddOneWordTvProgram(OneWordProgramTvDTO model)
        {
            var response = new ResponseMessage<string>();

            var oneWordProgram = new OneWordTvProgram();

            oneWordProgram.Id = Guid.NewGuid();
            oneWordProgram.Updated_at = DateTime.Now;
            oneWordProgram.Created_at = DateTime.Now;
            oneWordProgram.Hour = model.hour;
            oneWordProgram.Title = model.title;
            oneWordProgram.Day = (DayConstants)model.day;

            var result = await _oneWordProgramRepository.Add(oneWordProgram);

            if (result)
            {
                response.status = true;
                response.message = "Added Successfully";

                return response;
            }

            response.status = false;
            response.message = "An error occured";

            return response;
        }

        public Task<ResponseMessage<string>> UpdateOneWordTvProgram(OneWordProgramTvDTO model)
        {
            throw new NotImplementedException();
        }

        public List<OneWordTvProgram> GetAllOneWordTvPrograms()
        {
            var allPrograms = _oneWordProgramRepository.GetAll().ToList();

            return allPrograms;
        }

        public Task<List<OneWordTvProgram>> GetMyOneWordTvProgramsByDay(string day)
        {
            throw new NotImplementedException();
        }
    }
}
