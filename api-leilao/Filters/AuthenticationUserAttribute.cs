using api_leilao.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace api_leilao.Filters
{
    public class AuthenticationUserAttribute: AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

                var token = TokenOnRequest(context.HttpContext);

                var repository = new AuctionDbContext();
                var email = FromBase64String(token);

                var exist = repository.Users.Any(user => user.Email.Equals(email));
                if (exist == false)
                {
                    context.Result = new UnauthorizedObjectResult("Email not valid");
                }
            

        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token is missing.");
            }
            return authentication["Bearer ".Length..];

        }

        public string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }


}
