using AutoMapper;
using OneWordTvBackend.Helpers;
using OneWordTvBackend.Models;
using OneWordTvBackend.Models.Dto;
using OneWordTvBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWordTvBackend.Service
{
    public class OneWordTvService : IOneWordTvService
    {
        private readonly IOneWordProgramRepository _oneWordProgramRepository;
        private readonly IMapper _mapper;

        public OneWordTvService(IOneWordProgramRepository oneWordProgramRepository, IMapper mapper)
        {
            _oneWordProgramRepository = oneWordProgramRepository;
            _mapper = mapper;
        }

        public async Task<ResponseMessage<string>> AddOneWordTvProgram(OneWordProgramTvCreateDTO model)
        {
            var response = new ResponseMessage<string>();

            var oneWordDomain = _mapper.Map<OneWordTvProgram>(model);

            oneWordDomain.Id = Guid.NewGuid();
            oneWordDomain.Updated_at = DateTime.UtcNow;
            oneWordDomain.Created_at = DateTime.UtcNow;

            var result = await _oneWordProgramRepository.Add(oneWordDomain);

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

        public async Task<ResponseMessage<string>> UpdateOneWordTvProgram(OneWordProgramTvUpdateDTO model)
        {
            var response = new ResponseMessage<string>();

            var getProgram = await _oneWordProgramRepository.GetById(Guid.Parse(model.Id));
            if (getProgram == null)
            {
                response.status = false;
                response.message = "Program does not exist";

                return response;
            }
            getProgram.Title = model.title;
            getProgram.Hour = model.hour;
            getProgram.Day = (DayConstants)Enum.Parse(typeof(DayConstants), model.Day, true);

            if(await _oneWordProgramRepository.Modify(getProgram))
            {
                response.status = true;
                response.message = "Updated Successfully";

                return response;
            }

            response.status = false;
            response.message = "An error occured";

            return response;
        }

        public List<OneWordProgramTvUpdateDTO> GetAllOneWordTvPrograms()
        {
            var allPrograms = _oneWordProgramRepository.GetAll().ToList();
            var programsToDisplay = _mapper.Map<List<OneWordProgramTvUpdateDTO>>(allPrograms);

            return programsToDisplay;
        }

        public async Task<ResponseMessage<List<OneWordProgramTvUpdateDTO>>> GetMyOneWordTvProgramsByDay(string day)
        {
            var response = new ResponseMessage<List<OneWordProgramTvUpdateDTO>>();

            var programsByday = await _oneWordProgramRepository.GetMyOneWordTvProgramsByDay(day);
            if (programsByday != null)
            {
                response.data = _mapper.Map<List<OneWordProgramTvUpdateDTO>>(programsByday);
                response.status = true;
                response.message = "Operation Successful";
                return response;
            }
            response.status = false;
            response.message = "An Error Occurred";
            return response;
        }

        public async Task<ResponseMessage<string>> DeleteProgram(string id)
        {
            var response = new ResponseMessage<string>();

            if (await _oneWordProgramRepository.DeleteById(Guid.Parse(id)))
            {
                response.status = true;
                response.message = "Operation Successful";
                return response;
            }
            response.status = false;
            response.message = "An Error Occurred";
            return response;
        }
    }
}
