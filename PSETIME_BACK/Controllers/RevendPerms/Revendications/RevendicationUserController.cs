using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Revendications;
using PSETIME_BACK.DTO.VBM.RevendPerms;
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

        private readonly IRevendicationUserServices _revendicationUserServices;

        public RevendicationUserController(IRevendicationUserServices revendicationUserServices)
        {
            _revendicationUserServices = revendicationUserServices;
        }


        [HttpPost("create/Revendication")]
        public ActionResult CreateReven(RevendicationVbm model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var result = _revendicationUserServices.CreateRevendication(model);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAllPermissions(bool IsActive = true)
        {
            var result = _revendicationUserServices.GetAllstatus(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

    }
}
