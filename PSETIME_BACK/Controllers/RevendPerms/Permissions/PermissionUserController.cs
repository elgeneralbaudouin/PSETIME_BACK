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
    public class PermissionUserController : Controller
    {

        private readonly IPermissionUserServices _permissionUserServices;

        public PermissionUserController(IPermissionUserServices permissionUserServices)
        {
            _permissionUserServices = permissionUserServices;
        }

        [HttpGet("getall")]
        public ActionResult GetAllConfigs(bool IsActive = true)
        {
            var result = _permissionUserServices.GetAll(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }
    }
}
