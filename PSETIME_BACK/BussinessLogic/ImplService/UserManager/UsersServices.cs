using PSETIME_BACK.BussinessLogic.IService.UserManager;
using PSETIME_BACK.DAL.DAOs.IDAO.GlobalConfigs;
using PSETIME_BACK.DAL.DAOs.IDAO.UserManager;
using PSETIME_BACK.DTO.VBM.UserManager;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.UserManager;
using PSETIME_BACK.Helpers;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace PSETIME_BACK.BussinessLogic.ImplService.UserManager
{
    public class UsersServices : IUsersServices
    {

        /// <summary>
        ///  DI
        /// </summary>
        readonly IUserGroupsDao _userGroupsDao;
        readonly IGlobalConfigsDao _globalConfigsDao;
        public UsersServices(IUserGroupsDao userGroupsDao, IGlobalConfigsDao globalConfigsDao)
        {
            _userGroupsDao = userGroupsDao;
            _globalConfigsDao = globalConfigsDao;
        }

        /// <summary>
        ///     create group and his configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Response<String> CreateGroups(GroupsVbm model)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;


            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    var config = model.ToEntity();
                    config.BaseCreate("1", true);
                    _globalConfigsDao.Insert(config);

                    if (config.Id <= 0)
                    {
                        return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                    }

                    var group = model.ToEntity(config.Id);
                    group.BaseCreate("1", true);
                    _userGroupsDao.Insert(group);

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


        /// <summary>
        ///     update group and his configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Response<String> UpdateGroups(GroupsVbm model)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;


            try
            {

                using (TransactionScope scope = new TransactionScope())
                {

                    var group = _userGroupsDao.GetById(model.Id);

                    if (group == null)
                    {
                        return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                    }

                    var config = _globalConfigsDao.GetById(group.GlobalConfigId);


                    if (config == null)
                    {
                        return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                    }

                    config = model.ToEntity();
                    config.BaseUpdate("1", true);
                    _globalConfigsDao.Update(config);

                    group = model.ToEntity(config.Id);
                    group.BaseUpdate("1", true);
                    _userGroupsDao.Update(group);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public Response<List<UserGroupsVM>> GetAllGroups(bool IsActive = true)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;
            Int32 total = 0;
            var respVm = new List<UserGroupsVM>();

            try
            {

                var resp = _userGroupsDao.GetAll(IsActive);
                if (resp == null)
                {
                    return new Response<List<UserGroupsVM>>()
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

            return new Response<List<UserGroupsVM>>() { Data = respVm, Total = total, Success = message.Equals(MsgUtils.OK), Message = MsgUtils.OK, StackTrace = stackTrace };
        }






    }
}
