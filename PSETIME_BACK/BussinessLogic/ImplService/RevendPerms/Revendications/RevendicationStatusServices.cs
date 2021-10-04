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
    public class RevendicationStatusServices : IRevendicationStatusServices
    {

        // DI
        private readonly IRevendicationStatusDao _revendicationStatusDao;

        public RevendicationStatusServices(IRevendicationStatusDao revendicationStatusDao)
        {
            _revendicationStatusDao = revendicationStatusDao;
        }

        public Response<List<RevendicationStatusVM>> GetAll(bool IsActive = true)
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


    }
}
