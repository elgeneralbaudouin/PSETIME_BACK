using PSETIME_BACK.BussinessLogic.IService.GlobalConfigs;
using PSETIME_BACK.DAL.DAOs.IDAO.GlobalConfigs;
using PSETIME_BACK.DAL.Models.Entities.GlobalConfigs;
using PSETIME_BACK.DTO.VM;
using PSETIME_BACK.DTO.VM.GlobalConfigs;
using PSETIME_BACK.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.BussinessLogic.ImplService.GlobalConfigs
{
    /// <summary>
    ///     Services of globalconfiguration
    /// </summary>
    public class GlobalConfigsServices : IGlobalConfigsServices
    {
        // DI
        private readonly IGlobalConfigsDao _globalConfigsDao;

        public GlobalConfigsServices(IGlobalConfigsDao globalConfigsDao)
        {
            _globalConfigsDao = globalConfigsDao;
        }

        public Response<List<GlobalConfigsVM>> GetAll (bool IsActive = true) 
        {
            String message = MsgUtils.OK;
            String stackTrace = String.Empty;
            Int32 total = 0;

            var respVm = new List<GlobalConfigsVM>();

            try
            {
                var resp = _globalConfigsDao.GetAll(IsActive);
                if (resp == null)
                {
                    return new Response<List<GlobalConfigsVM>>()
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

            return new Response<List<GlobalConfigsVM>>() {  Data = respVm, Total = total, Success = message.Equals(MsgUtils.OK), Message = MsgUtils.OK, StackTrace = stackTrace };
        }
    }
}
