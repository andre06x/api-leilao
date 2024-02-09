using api_leilao.Contracts;
using api_leilao.Entites;
using api_leilao.Repositories;

namespace api_leilao.Services
{
    public class LoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _repository;
        public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) {
            _httpContextAccessor = httpContext;
            _repository = repository;
        }
        public User User()
        {
            var token = TokenOnRequest();
            var email = FromBase64String(token);
            return _repository.GetUserByEmail(email);
        }

        private string TokenOnRequest()
        {
            var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
            return authentication["Bearer ".Length..];

        }

        public string FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
