using PSETIME_BACK.DAL.Models.Entities.UserManager;

namespace PSETIME_BACK.DTO.VM.UserManager
{

    public class UserVM
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public int? SchoolId { get; set; }
        public bool IsActive { get; set; }




    }

    public static class UserExtentions
    {
        public static UserVM ToModel(this Users user)
        {
            UserVM userVM = new UserVM
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive
            };
            return userVM;
        }
    }

}
