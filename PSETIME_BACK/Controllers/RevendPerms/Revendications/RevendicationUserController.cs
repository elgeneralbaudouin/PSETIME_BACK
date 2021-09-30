using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Revendications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.Controllers.RevendPerms.Revendications
{

    [Route("api/[controller]")]
    [ApiController]
    public class RevendicationUserController : Controller
    {

        private readonly IRevendicationUsersServices _revendicationUserServices;

        public RevendicationUserController(IRevendicationUsersServices revendicationUserServices)
        {
            _revendicationUserServices = revendicationUserServices;
        }

        [HttpGet("getall")]
        public ActionResult GetAllConfigs(bool IsActive = true)
        {
            var result = _revendicationUserServices.GetAll(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

    }
}
