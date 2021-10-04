using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Permissions;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Permissions;
using PSETIME_BACK.DTO.VBM.RevendPerms;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms;
using PSETIME_BACK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PSETIME_BACK.BussinessLogic.ImplService.RevendPerms.Permissions
{
    public class PermissionUserServices : IPermissionUserServices
    {


        // DI
        readonly IPermissionUserDao _permissionUserDao;
        readonly IPermissionsStatusDao _permissionsStatusDao;

        public PermissionUserServices(IPermissionUserDao permissionUserDao, IPermissionsStatusDao permissionsStatusDao)
        {
            _permissionUserDao = permissionUserDao;
            _permissionsStatusDao = permissionsStatusDao;
        }



        /// <summary>
        ///     create permission , status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Response<String> CreatePermission(PermissionVbm model)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;


            try
            {

                using (TransactionScope scope = new TransactionScope())
            {
                var config = model.ToEntity();
                config.BaseCreate("1", true);
                _permissionsStatusDao.Insert(config);

                if (config.Id <= 0)
                {
                    return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                }

                var perm = model.ToEntity(config.Id);
                perm.BaseCreate("1", true);
                _permissionUserDao.Insert(perm);

                scope.Complete();
            }
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

            return new Response<String>() { Data = message, Total = 1, Success = message.Equals(MsgUtils.OK), Message = message, StackTrace = stackTrace };
        }

        public Response<List<PermissionUserVM>> GetAllPermission(bool IsActive = true)
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

            return new Response<List<PermissionUserVM>>() { Data = respVm, Total = total, Success = message.Equals(MsgUtils.OK), Message = MsgUtils.OK, StackTrace = stackTrace };


        }

        public Response<List<PermissionUserVM>> GetAllstatus(bool IsActive = true)
        {
            throw new NotImplementedException();
        }
    }
}
