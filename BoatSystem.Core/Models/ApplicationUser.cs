namespace BoatSystem.Core.Models
{
    using Microsoft.AspNetCore.Identity;


    public static class SwaggerDocsConstant
    {
        public const string Admin = "admin";
        public const string User = "user";
    }


    public class ApplicationUser : IdentityUser
    {
    }

    public class AuthModel
    {
        public string Message { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        
    }

    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }


    public class TokenRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
