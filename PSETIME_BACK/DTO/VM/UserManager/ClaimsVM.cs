using PSETIME_BACK.DAL.Models.Entities.UserManager;

namespace PSETIME_BACK.DTO.VM.UserManager
{

    public class ClaimsVM
    {
        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string MenuParent { get; set; }
    }

    public class ClaimVM2
    {
        public string Value { get; set; }
        public bool Status { get; set; }
    }

    public static class ClaimsExtention
    {
        public static ClaimsVM ToModel(this Claims claim)
        {
            ClaimsVM model = new ClaimsVM();

            model.ClaimId = claim.Id;
            model.ClaimType = claim.ClaimsType;
            model.ClaimValue = claim.ClaimsValue;

            return model;
        }
    }

}
