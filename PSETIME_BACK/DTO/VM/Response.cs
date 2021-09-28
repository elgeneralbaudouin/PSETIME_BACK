using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSETIME_BACK.DTO.VM
{
    /// <summary>
    ///     Use to retrieve a response to controller with specific typ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public String Message { get; set; }
        public String StackTrace { get; set; }
        public Boolean Success { get; set; }
        public Int32 Total { get; set; }
        public T Data { get; set; }
        public String Privileges { get; set; }


    }
}
