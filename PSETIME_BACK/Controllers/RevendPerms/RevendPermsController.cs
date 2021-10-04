using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.RevendPerms;
using PSETIME_BACK.DTO.VBM.RevendPerms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.Controllers.RevendPerms
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevendPermsController : Controller
    {
        private readonly IRevendPermsServices  _revendPermsServices;

        public RevendPermsController(IRevendPermsServices revendPermsServices)
        {
            _revendPermsServices = revendPermsServices;
        }


        [HttpGet("getallpermission_status")]
        public ActionResult GetAllStatut(bool IsActive = true)
        {
            var result = _revendPermsServices.GetAllPermissionStatus(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }




        [HttpPost("create/permission")]
        public ActionResult CreatePermission(PermissionVbm model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var result = _revendPermsServices.CreatePermission(model);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getall_permission")]
        public ActionResult GetAllPermissions(bool IsActive = true)
        {
            var result = _revendPermsServices.GetAllPermission(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }





        [HttpGet("getallrevendication_status")]
        public ActionResult GetAllRevendicationStatus(bool IsActive = true)
        {
            var result = _revendPermsServices.GetAllRevendicationStatus(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }



        [HttpPost("create/revendication")]
        public ActionResult CreateRevendications(RevendicationVbm model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var result = _revendPermsServices.CreateRevendication(model);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getall_revendication")]
        public ActionResult GetAllRevendications(bool IsActive = true)
        {
            var result = _revendPermsServices.GetAllRevendication(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }



    }
}
