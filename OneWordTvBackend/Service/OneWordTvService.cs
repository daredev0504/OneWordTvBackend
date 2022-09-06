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
using OneWordTvBackend.Repository.Interface;

namespace OneWordTvBackend.Service
{
    public class OneWordTvService : IOneWordTvService
    {
        private readonly IOneWordTvMongo _oneWordProgramRepositoryMongo;
        private readonly IMapper _mapper;

        public OneWordTvService(IOneWordTvMongo oneWordProgramRepositoryMongo, IMapper mapper)
        {
            _oneWordProgramRepositoryMongo = oneWordProgramRepositoryMongo;
            _mapper = mapper;
        }

        public async Task<ResponseMessage<string>> AddOneWordTvProgram(OneWordProgramTvCreateDTO model)
        {
            var response = new ResponseMessage<string>();

            var oneWordDomain = _mapper.Map<OneWordTvProgram>(model);

            oneWordDomain.Id = Guid.NewGuid();
            oneWordDomain.Updated_at = DateTime.UtcNow;
            oneWordDomain.Created_at = DateTime.UtcNow;

            var result = await _oneWordProgramRepositoryMongo.AddProgram(oneWordDomain);

            if (result != null)
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

            var getProgram = await _oneWordProgramRepositoryMongo.GetProgramById(model.Id);
            if (getProgram == null)
            {
                response.status = false;
                response.message = "Program does not exist";

                return response;
            }
            getProgram.Title = model.title;
            getProgram.Hour = model.hour;
            getProgram.Updated_at = DateTime.Now;
            getProgram.Day = (DayConstants)Enum.Parse(typeof(DayConstants), model.Day, true);

            var result = await _oneWordProgramRepositoryMongo.UpdateProgram(getProgram.Id.ToString(), getProgram);
            if (result.IsAcknowledged)
            {
                response.status = result.IsAcknowledged;
                response.message = "Updated Successfully";

                return response;
            }

            response.status = false;
            response.message = "An error occured";

            return response;
        }

        public async Task<ResponseMessage<List<OneWordProgramTvUpdateDTO>>> GetAllOneWordTvPrograms()
        {
            var response = new ResponseMessage<List<OneWordProgramTvUpdateDTO>>();

            var allPrograms = await _oneWordProgramRepositoryMongo.GetAllPrograms();

            var programsToDisplay = _mapper.Map<List<OneWordProgramTvUpdateDTO>>(allPrograms);

            if (allPrograms != null)
            {
                response.status = true;
                response.message = "Records returned Successfully";
                response.data = programsToDisplay;

                return response;
            }

            response.status = false;
            response.message = "An error occured";

            return response;
        }

        //public async Task<ResponseMessage<List<OneWordProgramTvUpdateDTO>>> GetMyOneWordTvProgramsByDay(string day)
        //{
        //    var response = new ResponseMessage<List<OneWordProgramTvUpdateDTO>>();

        //    var programsByday = await _oneWordProgramRepositoryMongo.GetMyOneWordTvProgramsByDay(day);
        //    if (programsByday != null)
        //    {
        //        response.data = _mapper.Map<List<OneWordProgramTvUpdateDTO>>(programsByday);
        //        response.status = true;
        //        response.message = "Operation Successful";
        //        return response;
        //    }
        //    response.status = false;
        //    response.message = "An Error Occurred";
        //    return response;
        //}

        public async Task<ResponseMessage<string>> DeleteProgram(string id)
        {
            var response = new ResponseMessage<string>();

            var result = await _oneWordProgramRepositoryMongo.DeleteProgram(id);

            if (result.IsAcknowledged)
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
