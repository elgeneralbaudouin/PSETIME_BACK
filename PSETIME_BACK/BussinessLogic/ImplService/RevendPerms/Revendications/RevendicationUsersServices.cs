using PSETIME_BACK.BussinessLogic.IService.RevendPerms.Revendications;
using PSETIME_BACK.DAL.DAOs.IDAO.RevendPerms.Revendications;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.RevendPerms.Revendications;
using PSETIME_BACK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.ImplService.RevendPerms.Revendications
{
    public class RevendicationUsersServices : IRevendicationUsersServices
    {

        // DI
        private readonly IRevendicationUserDao _revendicationUsersDao;

        public RevendicationUsersServices(IRevendicationUserDao revendicationUsersDao)
        {
            _revendicationUsersDao = revendicationUsersDao;
        }

        public Response<List<RevendicationUserVM>> GetAll(bool IsActive = true)
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
    }
}
