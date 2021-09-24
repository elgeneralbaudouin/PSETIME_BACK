using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.GlobalConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.Controllers.GlobalConfigs
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : Controller
    {

        private readonly IGlobalConfigsServices _globalConfigsServices;

        public ConfigController(IGlobalConfigsServices globalConfigsServices)
        {
            _globalConfigsServices = globalConfigsServices;
        }

        [HttpGet("getall")]
        public ActionResult CreateCandidate(bool IsActive = true)
        {
            var result = _globalConfigsServices.GetAll(IsActive);

            return Ok(result);
        }
    }
}
