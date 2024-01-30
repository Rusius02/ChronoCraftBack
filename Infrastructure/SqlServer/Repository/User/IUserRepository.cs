using System.Collections.Generic;

namespace Infrastructure.SqlServer.Repository.User
{
    //This is where we declare all our User Repository methods
    public interface IUserRepository
    {
        Domain.User Create(Domain.User user);

        List<Domain.User> GetAll();

        Domain.User GetUser(Domain.User users);

        bool Delete(Domain.User users);

        bool Update(Domain.User users);

        Domain.User GetUserByPseudo(string pseudo, string password);

    }
}