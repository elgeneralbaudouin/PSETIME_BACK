using PSETIME_BACK.DAL.Models.Entities.UserManager;
using System;
using System.Collections.Generic;

namespace PSETIME_BACK.DTO.VM.UserManager
{
    public class UserManageResponse
    {
        public List<ClaimVM2> MenuClaims { get; set; }
        public List<ClaimVM2> PrivClaims { get; set; }
        public String Token { get; set; }
        public String Name { get; set; }
        public Users User { get; set; }
        public String Role { get; set; }
        public String Message { get; set; }
        public bool Success { get; set; }
        public string StackTrace { get; set; }
        public IEnumerable<string> errors { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }

    public class ManageResponse<T>
    {
        public string StackTrace { get; set; }
        public String Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> errors { get; set; }
        public T Data { get; set; }
        public int Total { get; set; }
    }
}
