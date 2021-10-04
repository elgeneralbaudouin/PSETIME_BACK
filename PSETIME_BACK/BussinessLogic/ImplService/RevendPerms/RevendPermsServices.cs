using PSETIME_BACK.BussinessLogic.IService.RevendPerms;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms;
using PSETIME_BACK.DTO.VBM.RevendPerms;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms;
using PSETIME_BACK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PSETIME_BACK.BussinessLogic.ImplService.RevendPerms
{
    public class RevendPermsServices : IRevendPermsServices
    {
        private readonly IPermissionsStatusDao _permissionsStatusDao;
        private readonly IPermissionUserDao _permissionUserDao;

        private readonly IRevendicationUserDao _revendicationUsersDao;
        private readonly IRevendicationStatusDao _revendicationStatusDao;
        public RevendPermsServices(IPermissionUserDao permissionUserDao, IPermissionsStatusDao permissionsStatusDao, IRevendicationUserDao revendicationUsersDao, IRevendicationStatusDao revendicationStatusDao)
        {
            _permissionUserDao = permissionUserDao;
            _permissionsStatusDao = permissionsStatusDao;

            _revendicationUsersDao = revendicationUsersDao;
            _revendicationStatusDao = revendicationStatusDao;

        }


        #region Permissions
        /// <summary>
        ///     List active permissions status 
        /// </summary>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public Response<List<PermissionsStatusVM>> GetAllPermissionStatus(bool IsActive = true)
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


                var permStatus = _permissionsStatusDao.GetById(model.PermissionsStatusId);

                    if (permStatus == null)
                    {
                        return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                    }

                    var perm = model.ToEntity(permStatus.Id);
                    perm.BaseCreate("1", true);
                    _permissionUserDao.Insert(perm);

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

        /// <summary>
        ///     List all permissions 
        ///     
        /// </summary>
        /// <param name="IsActive"></param>
        /// <returns></returns>
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

        #endregion


        #region Revendications

        /// <summary>
        ///     List revendications
        /// </summary>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public Response<List<RevendicationStatusVM>> GetAllRevendicationStatus(bool IsActive = true)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;
            Int32 total = 0;

            var respVm = new List<RevendicationStatusVM>();

            try
            {
                var resp = _revendicationStatusDao.GetAll(IsActive);
                if (resp == null)
                {
                    return new Response<List<RevendicationStatusVM>>()
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

            return new Response<List<RevendicationStatusVM>>() { Data = respVm, Total = total, Success = message.Equals(MsgUtils.OK), Message = MsgUtils.OK, StackTrace = stackTrace };
        }

        /// <summary>
        ///     create permission
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Response<String> CreateRevendication(RevendicationVbm model)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;


            try
            {

               
                    if (model.Name == null)
                    {
                        return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                    }

                    var revend = model.ToEntity();
                    revend.BaseCreate("1", true);
                    _revendicationUsersDao.Insert(revend);

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

        /// <summary>
        ///     List revendications
        /// </summary>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public Response<List<RevendicationUserVM>> GetAllRevendication(bool IsActive = true)
        {

            String message = MsgUtils.OK;
            String stackTrace = String.Empty;
            Int32 total = 0;
            var respVm = new List<RevendicationUserVM>();

            try
            {

                var resp = _revendicationUsersDao.GetAll(IsActive);
                if (resp == null)
                {
                    return new Response<List<RevendicationUserVM>>()
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

            return new Response<List<RevendicationUserVM>>() { Data = respVm, Total = total, Success = message.Equals(MsgUtils.OK), Message = MsgUtils.OK, StackTrace = stackTrace };


        }


        #endregion
    }
}
