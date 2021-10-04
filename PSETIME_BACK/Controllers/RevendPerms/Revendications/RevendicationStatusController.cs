using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.ImplService.RevendPerms.Revendications;
using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Revendications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.Controllers.RevendPerms.Revendications
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevendicationStatusController : Controller
    {

        private readonly IRevendicationStatusServices _revendicationStatusServices;

        public RevendicationStatusController(IRevendicationStatusServices revendicationStatusServices)
        {
            _revendicationStatusServices = revendicationStatusServices;
        }

        [HttpGet("getall")]
        public ActionResult GetAllStatut(bool IsActive = true)
        {
            var result = _revendicationStatusServices.GetAll(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

    }
}
