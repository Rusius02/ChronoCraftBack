using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repository.User
{
    public class UserFactory : IDomainFactory<Domain.Users>
    {
        /*Here we have our class that will load our data from the data table into a new User*/
        public Domain.Users CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.Users()
            {
                Id = reader.GetInt32(reader.GetOrdinal(UserRepository.ColId)),
                LastName = reader.GetString(reader.GetOrdinal(UserRepository.ColLastName)),
                FirstName = reader.GetString(reader.GetOrdinal(UserRepository.ColFirstName)),
                sexe = reader.GetString(reader.GetOrdinal(UserRepository.ColSexe)),
                BirthDate = reader.GetDateTime(reader.GetOrdinal(UserRepository.ColBirthdate)),
                mail = reader.GetString(reader.GetOrdinal(UserRepository.ColMail)),
                pseudo = reader.GetString(reader.GetOrdinal(UserRepository.ColPseudo)),
                Password = reader.GetString(reader.GetOrdinal(UserRepository.ColPassword)),
                Role = reader.GetString(reader.GetOrdinal(UserRepository.ColRole))
                    
            };
        }
    }
}