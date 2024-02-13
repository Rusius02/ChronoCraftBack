using ContosoUniversity.Models;
using Domain;
using Infrastructure;
using System;
using System.Diagnostics;
using System.Linq;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Database context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{FirstName="Carson",LastName="Alexander",UserName= "Caal", EmailAdress="Carson.Alexander@hotmail.com", Password="PW$1234", Address="Rue de Bruxelles", City="LLN", PostCode="2000", Country="Belgium", BirthDate=DateTime.Parse("2005-09-01"), BirthCity="LLN", PhoneNumber="0032477889922", Sexe="M",Role="Admin" },
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var plans = new Plan[]
            {
            new Plan{CourseID=1050,Title="Chemistry",Credits=3},
            };
            foreach (Plan c in plans)
            {
                context.Plans.Add(c);
            }
            context.SaveChanges();

            var chronos = new Chrono[]
            {
            new Chrono{StudentID=1,CourseID=1050,Grade=Grade.A},
            };
            foreach (Chrono e in chronos)
            {
                context.Chronos.Add(e);
            }
            context.SaveChanges();
        }
    }
}