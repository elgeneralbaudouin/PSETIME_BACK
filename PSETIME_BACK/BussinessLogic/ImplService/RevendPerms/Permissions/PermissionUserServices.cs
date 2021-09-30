using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Permissions;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Permissions;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms;
using PSETIME_BACK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.ImplService.RevendPerms.Permissions
{
    public class PermissionUserServices : IPermissionUserServices
    {


        // DI
        private readonly IPermissionUserDao _permissionUserDao;

        public PermissionUserServices(IPermissionUserDao permissionUserDao)
        {
            _permissionUserDao = permissionUserDao;
        }

        public Response<List<PermissionUserVM>> GetAll(bool IsActive = true)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;
            Int32 total = 0;

            var respVm = new List<PermissionUserVM>();

            try
            {
                var resp = _permissionUserDao.GetAll(IsActive);
                if (resp == null)
                {
                    return new Response<List<PermissionUserVM>>()
                    {
                        Success = true,
                        Message = MsgUtils.NO_DATA
                    };
                }
                respVm = resp.ToVMs();
                total = respVm.Count;
            }
            catch (Exception e)
            {
                message = e.StackTrace;
                if (e.InnerException != null)
                {
                    message = e.InnerException.Message;
                }

                stackTrace = e.StackTrace;

            }

            return new Response<List<PermissionUserVM>>() { Data = respVm, Total = total, Success = message.Equals(MsgUtils.OK), Message = message, StackTrace = stackTrace };
        }

    }
}
