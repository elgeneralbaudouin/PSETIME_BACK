using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.Imports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.Controllers.Imports
{

    [Route("api/[controller]")]
    [ApiController]
    public class ImportationController : Controller
    {

        private readonly IImportationServices _importationServices;

        public ImportationController(IImportationServices importationServices)
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
