using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Permissions;
using PSETIME_BACK.DTO.VBM.RevendPerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.Controllers.RevendPerms.Permissions
{
    #region nn

    #endregion



    [Route("api/u")]
    [ApiController]

    public class PermissionUserController : Controller
    {
        readonly IPermissionUserServices _permissionUserServices;

        public PermissionUserController(IPermissionUserServices permissionUserServices)
        {
            _permissionUserServices = permissionUserServices;
        }

        [HttpPost("create/Permission")]
        public ActionResult CreatePermis(PermissionVbm model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var result = _permissionUserServices.CreatePermission(model);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAllPermissions(bool IsActive = true)
        {
            var result = _permissionUserServices.GetAllstatus(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

    }
}
