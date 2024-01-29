using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repository.User
{
    public partial class UserRepository : IUserRepository
    {
       private readonly Database database;

        public UserRepository(Database context)
        {
            database = context;
        }

        public void AddUser(Domain.User user)
        {
            database.Users.Add(user);
            database.SaveChanges();
        }

    }
}