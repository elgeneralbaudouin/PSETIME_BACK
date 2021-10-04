using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Permissions;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Permissions;
using PSETIME_BACK.DAL.Models.Entities.RevendPerms.Permissions;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms.Permissions;
using PSETIME_BACK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.ImplService.RevendPerms.Permissions
{
    public class PermissionsStatusServices : IPermissionsStatusServices
    {

        // DI
        private readonly IPermissionsStatusDao _permissionsStatusDao;

        public PermissionsStatusServices(IPermissionsStatusDao permissionsStatusDao)
        {
            _permissionsStatusDao = permissionsStatusDao;
        }

        public Response<List<PermissionsStatusVM>> GetAll(bool IsActive = true)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;
            Int32 total = 0;

            var respVm = new List<PermissionsStatusVM>();

            try
            {
                var resp = _permissionsStatusDao.GetAll(IsActive);
                if (resp == null)
                {
                    return new Response<List<PermissionsStatusVM>>()
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

            return new Response<List<PermissionsStatusVM>>() { Data = respVm, Total = total, Success = message.Equals(MsgUtils.OK), Message = MsgUtils.OK, StackTrace = stackTrace };
        }
    }
}
