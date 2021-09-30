using Microsoft.AspNetCore.Mvc;
using PSETIME_BACK.BussinessLogic.IService.UserManager;
using PSETIME_BACK.DTO.VBM.UserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.Controllers.UserManager
{
    /// <summary>
    ///     prefix des routes de gestion de l'utilisateur par "api/u"
    ///     en lieu et place de "api/Users"
    /// </summary>
    [Route("api/u")]
    [ApiController]
    public class UsersController : Controller
    {
        readonly IUsersServices _usersServices;
        public UsersController(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }

        [HttpPost("create/group")]
        public ActionResult CreateGroup(GroupsVbm model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var result = _usersServices.CreateGroups(model);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAllConfigs(bool IsActive = true)
        {
            var result = _usersServices.GetAllGroups(IsActive);
            if (!result.Success)
            {
                return StatusCode(500, result.Message);
            }
            return Ok(result);
        }
    }
}
