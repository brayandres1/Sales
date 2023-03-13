using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Sales.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonimous = new ClaimsIdentity();
            var AndresVelez = new ClaimsIdentity(new List<Claim>
             {
                 new Claim("FirstName", "Andres"),
                 new Claim("LastName", "Velez"),
                 new Claim(ClaimTypes.Name, "avelez@yopmail.com"),
                 new Claim(ClaimTypes.Role, "Admin")
             },
            authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(AndresVelez)));

        }
    }
}
