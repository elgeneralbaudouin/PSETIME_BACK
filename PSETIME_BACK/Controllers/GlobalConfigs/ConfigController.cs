using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.GlobalConfigs;

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
        public ActionResult GetAllConfigs(bool IsActive = true)
        {
            var result = _globalConfigsServices.GetAll(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }
    }
}
