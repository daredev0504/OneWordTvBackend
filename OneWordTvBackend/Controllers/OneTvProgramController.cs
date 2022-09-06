using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneWordTvBackend.Models.Dto;
using OneWordTvBackend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneWordTvBackend.Repository.Interface;

namespace OneWordTvBackend.Controllers
{
    public class OneTvProgramController : BaseApiController
    {
        private readonly IOneWordTvService _oneWordTvService;
        public OneTvProgramController(IOneWordTvService oneWordService, IOneWordTvMongo oneWordTvMongo)
        {
            _oneWordTvService = oneWordService;
        }

        [HttpPost("CreateProgram")]
        public async Task<IActionResult> CreateOneTvProgram(OneWordProgramTvCreateDTO model)
        {
            var resp = await _oneWordTvService.AddOneWordTvProgram(model);
            return Ok(resp);
        }

        [HttpPost("EditProgram")]
        public async Task<IActionResult> UpdateProgram(OneWordProgramTvUpdateDTO model)
        {
            var resp = await _oneWordTvService.UpdateOneWordTvProgram(model);
            return Ok(resp);
        }


        [HttpGet("GetAllPrograms")]
        public async Task<IActionResult> GetAllOneTvPrograms()
        {
            var resp = await _oneWordTvService.GetAllOneWordTvPrograms();
            return Ok(resp);
        }


        //[HttpGet("GetAllProgramsByDay")]
        //public async Task<IActionResult> GetAllOneTvProgramsByDay(string model)
        //{
        //    var resp = await _oneWordTvService.GetMyOneWordTvProgramsByDay(model);
        //    return Ok(resp);
        //}

        [HttpDelete("DeleteProgram")]
        public async Task<IActionResult> DeleteOneTvProgram(string id)
        {
            var resp = await _oneWordTvService.DeleteProgram(id);
            return Ok(resp);
        }
    }
}
