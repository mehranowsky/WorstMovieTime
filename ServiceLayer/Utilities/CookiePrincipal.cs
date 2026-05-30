using ModelLayer.Models;
using System.Security.Claims;


namespace ServiceLayer.Utilities
{
    public class CookiePrincipal
    {
        public static ClaimsPrincipal AllotCookie(Users user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };
            var identity = new ClaimsIdentity(claims, "Cookies");
            var claimsPrincipal = new ClaimsPrincipal(identity);
            return claimsPrincipal;
        }
    }
}
