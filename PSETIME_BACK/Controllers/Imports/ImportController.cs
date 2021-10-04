﻿using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.Imports;

namespace PSETIME_BACK.Controllers.Imports
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImportationController : Controller
    {

        private readonly IImportServices _importationServices;

        public ImportationController(IImportServices importationServices)
        {
            _importationServices = importationServices;
        }

        [HttpGet("getall")]
        public ActionResult CreateCandidate(bool IsActive = true)
        {
            var result = _importationServices.GetAll(IsActive);

            return Ok(result);
        }

    }
}
