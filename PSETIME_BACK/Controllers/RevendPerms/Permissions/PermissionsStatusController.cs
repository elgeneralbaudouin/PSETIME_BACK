using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.Controllers.RevendPerms.Permissions
{

    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsStatusController : Controller
    {
        private readonly IPermissionsStatusServices _permissionsStatusServices;

        public PermissionsStatusController(IPermissionsStatusServices permissionsStatusServices)
        {
            _permissionsStatusServices = permissionsStatusServices;
        }

        [HttpGet("getall")]
        public ActionResult GetAllStatut(bool IsActive = true)
        {
            var result = _permissionsStatusServices.GetAll(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }
    }
}
