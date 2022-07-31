using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneWordTvBackend.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneWordTvBackend.Controllers
{
    public class OneTvProgramController : BaseApiController
    {
        private readonly IOneWordTvService _oneWordTvService;
        public OneTvProgramController(IOneWordTvService oneWordService)
        {
            _oneWordTvService = oneWordService;
        }

        // GET: ProgramsController/Create
        public IActionResult Create()
        {
            return Ok();
        }

        // GET: ProgramsController/Edit/5
        public ActionResult Edit(int id)
        {
            return Ok();
        }


        // GET: ProgramsController/Delete/5
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
