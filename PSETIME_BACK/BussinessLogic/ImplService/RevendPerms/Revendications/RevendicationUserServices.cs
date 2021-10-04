using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Revendications;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Revendications;
using PSETIME_BACK.DTO.VBM.RevendPerms;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms.Revendications;
using PSETIME_BACK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PSETIME_BACK.BussinessLogic.ImplService.RevendPerms.Revendications
{
    public class RevendicationUserServices : IRevendicationUserServices
    {

        // DI
        private readonly IRevendicationUserDao _revendicationUsersDao;
        private readonly IRevendicationStatusDao _revendicationStatusDao;

        public RevendicationUserServices(IRevendicationUserDao revendicationUsersDao, IRevendicationStatusDao revendicationStatusDao)
        {
            _revendicationUsersDao = revendicationUsersDao;
            _revendicationStatusDao = revendicationStatusDao;
        }

        /// <summary>
        ///     create permission , status
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Response<String> CreateRevendication(RevendicationVbm model)
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;


            try
            {

                using (TransactionScope scope = new TransactionScope())
                {
                    var config = model.ToEntity();
                    config.BaseCreate("1", true);
                    _revendicationStatusDao.Insert(config);

                    if (config.Id <= 0)
                    {
                        return new Response<string>() { Message = MsgUtils.BAD_PARAMETERS, Success = false };
                    }

                    var perm = model.ToEntity(config.Id);
                    perm.BaseCreate("1", true);
                    _revendicationUsersDao.Insert(perm);

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


        public Response<List<RevendicationUserVM>> GetAllPermission(bool IsActive = true)
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

        public Response<List<RevendicationUserVM>> GetAllstatus(bool IsActive = true)
        {
            throw new NotImplementedException();
        }

        
    }
}
