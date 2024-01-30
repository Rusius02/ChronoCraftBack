using System.Data.SqlClient;
using Infrastructure.SqlServer.Utils;

namespace Infrastructure.SqlServer.Repository.User
{
    public class UserFactory : IDomainFactory<Domain.User>
    {
        /*Here we have our class that will load our data from the data table into a new User*/
        public Domain.User CreateFromSqlReader(SqlDataReader reader)
        {
            return new Domain.User()
            {
                Id = reader.GetInt32(reader.GetOrdinal(UserRepository.ColId)),
                FirstName = reader.GetString(reader.GetOrdinal(UserRepository.ColFirstName)),
                LastName = reader.GetString(reader.GetOrdinal(UserRepository.ColLastName)),
                UserName = reader.GetString(reader.GetOrdinal(UserRepository.ColUserName)),
                EmailAdress = reader.GetString(reader.GetOrdinal(UserRepository.ColEmailAddress)),
                Password = reader.GetString(reader.GetOrdinal(UserRepository.ColPassword)),
                Address = reader.GetString(reader.GetOrdinal(UserRepository.ColAddress)),
                City = reader.GetString(reader.GetOrdinal(UserRepository.ColCity)),
                PostCode = reader.GetString(reader.GetOrdinal(UserRepository.ColPostcode)),
                Country = reader.GetString(reader.GetOrdinal(UserRepository.ColCountry)),
                BirthDate = reader.GetDateTime(reader.GetOrdinal(UserRepository.ColBirthdate)),
                BirthCity = reader.GetString(reader.GetOrdinal(UserRepository.ColBirthcity)),
                PhoneNumber = reader.GetString(reader.GetOrdinal(UserRepository.ColPhoneNumber)),
                Sexe = reader.GetString(reader.GetOrdinal(UserRepository.ColSexe))       
            };
        }
    }
}