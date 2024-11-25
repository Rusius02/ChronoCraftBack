﻿using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using Infrastructure.SqlServer.Repository.User;
using Infrastructure.SqlServer.Utils;
using NotImplementedException = System.NotImplementedException;

namespace Infrastructure.SqlServer.Repository.User
{
    public partial class UserRepository : IUserRepository
    {
        private readonly IDomainFactory<Domain.User> _factory = new UserFactory();

        //The Create method creates and returns an User
        public Domain.User Create(Domain.User user)
        {
            /*We connect to our database*/
            using var connection = Database.GetConnection();
            List<Domain.User> users = GetAll();
            connection.Open();

            //We call our request from the UserRequest class
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqCreate
            };
            /*We pass the received data as an argument in our request*/
            command.Parameters.AddWithValue("@" + ColFirstName, user.FirstName);
            command.Parameters.AddWithValue("@" + ColLastName, user.LastName);
            command.Parameters.AddWithValue("@" + ColUserName, user.UserName);
            command.Parameters.AddWithValue("@" + ColEmailAddress, user.EmailAdress);
            command.Parameters.AddWithValue("@" + ColPassword, user.Password);
            command.Parameters.AddWithValue("@" + ColAddress, user.Address);
            command.Parameters.AddWithValue("@" + ColCity, user.City);
            command.Parameters.AddWithValue("@" + ColPostcode, user.PostCode);
            command.Parameters.AddWithValue("@" + ColCountry, user.Country);
            command.Parameters.AddWithValue("@" + ColBirthdate, user.BirthDate);
            command.Parameters.AddWithValue("@" + ColBirthcity, user.BirthCity);
            command.Parameters.AddWithValue("@" + ColPhoneNumber, user.PhoneNumber);
            command.Parameters.AddWithValue("@" + ColSexe, user.Sexe);
            command.Parameters.AddWithValue("@" + ColNationality, user.Nationality);
            command.Parameters.AddWithValue("@" + ColRole, user.Role);



            //We do a check to see if the Activity exists based on pseudo, mail and password
            foreach (Domain.User u in users)
            {
                if (u.EmailAdress == user.EmailAdress && u.UserName == user.UserName && u.Password == user.Password)
                {
                    return null;
                }
            }
            user.Id = (int)command.ExecuteScalar();

            return user;
        }

        /*The GetAll method will return a List of Users*/
        public List<Domain.User> GetAll()
        {
            var users = new List<Domain.User>();
            /*We connect to our database*/
            using var connection = Database.GetConnection();
            connection.Open();

            //We call our request from the ActivityRequest class
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetAll
            };

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            //We get our values and add them to the List 
            while (reader.Read())
            {
                users.Add(_factory.CreateFromSqlReader(reader));
            }

            return users;
        }

        //The GetUser method will return an User based on its idUser
        public Domain.User GetUser(Domain.User users)
        {
            /*We connect to our database*/
            using var connection = Database.GetConnection();
            connection.Open();

            //We call our request from the SportRequest class
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetById
            };

            /*We pass the received data as an argument in our request*/
            command.Parameters.AddWithValue("@" + ColId, users.Id);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return reader.Read() ? _factory.CreateFromSqlReader(reader) : null;
        }

        //The Delete method deletes an User based on the id
        public bool Delete(Domain.User user)
        {
            /*We connect to our database*/
            using var connection = Database.GetConnection();
            connection.Open();

            //We call our request from the UserRequest class
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqDelete
            };
            /*We pass the received data as an argument in our request*/
            command.Parameters.AddWithValue("@" + ColId, user.Id);
            return command.ExecuteNonQuery() > 0;
        }

        //The Update method allows you to modify an activity
        public bool Update(Domain.User users)
        {
            /*We connect to our database*/
            using var connection = Database.GetConnection();
            connection.Open();

            //We call our request from the ActivityRequest class
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqUpdate
            };

            /*We pass the received data as an argument in our request*/
            command.Parameters.AddWithValue("@" + ColId, users.Id);
            command.Parameters.AddWithValue("@" + ColFirstName, users.FirstName);
            command.Parameters.AddWithValue("@" + ColLastName, users.LastName);
            command.Parameters.AddWithValue("@" + ColUserName, users.UserName);         
            command.Parameters.AddWithValue("@" + ColEmailAddress, users.EmailAdress);
            command.Parameters.AddWithValue("@" + ColPassword, users.Password);
            command.Parameters.AddWithValue("@" + ColAddress, users.Address);
            command.Parameters.AddWithValue("@" + ColCity, users.City);
            command.Parameters.AddWithValue("@" + ColPostcode, users.PostCode);
            command.Parameters.AddWithValue("@" + ColCountry, users.Country);
            command.Parameters.AddWithValue("@" + ColBirthdate, users.BirthDate);
            command.Parameters.AddWithValue("@" + ColBirthcity, users.BirthCity);
            command.Parameters.AddWithValue("@" + ColPhoneNumber, users.PhoneNumber);
            command.Parameters.AddWithValue("@" + ColSexe, users.Sexe);
            command.Parameters.AddWithValue("@" + ColRole, users.Role);
            command.Parameters.AddWithValue("@" + ColNationality, users.Nationality);
            return command.ExecuteNonQuery() > 0;
        }

        //The GetUserByPseudo method will return an activity based on its pseudo and password
        public Domain.User GetUserByPseudo(string username, string password)
        {
            /*We connect to our database*/
            using var connection = Database.GetConnection();
            connection.Open();

            //We call our request from the UserRequest class
            var command = new SqlCommand
            {
                Connection = connection,
                CommandText = ReqGetByPseudo
            };

            /*We pass the received data as an argument in our request*/
            command.Parameters.AddWithValue("@" + ColUserName, username);
            command.Parameters.AddWithValue("@" + ColPassword, password);

            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return reader.Read() ? _factory.CreateFromSqlReader(reader) : null;
        }
    }
}