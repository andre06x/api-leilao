using api_leilao.Entites;

namespace api_leilao.Contracts
{
    public interface IUserRepository
    {
        bool ExistUserWithEmail(string email);

        User GetUserByEmail(string email);

    }
}
