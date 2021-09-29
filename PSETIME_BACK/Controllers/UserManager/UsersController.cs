using Microsoft.AspNetCore.Mvc;
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
    }
}
