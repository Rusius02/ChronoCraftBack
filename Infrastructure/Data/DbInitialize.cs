using Domain;

namespace Infrastructure
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
            new User{FirstName="Carson",LastName="Alexander",UserName= "Caal", EmailAdress="Carson.Alexander@hotmail.com", Password="PW$1234", Address="Rue de Bruxelles", City="LLN", PostCode="2000", Country="Belgium", BirthDate=DateTime.Parse("2005-09-01"), BirthCity="LLN", PhoneNumber="0032477889922", Sexe="M",Role=Role.Admin },
            new User{FirstName="Carson",LastName="Alexander",UserName= "Caal", EmailAdress="Carson.Alexander@hotmail.com", Password="PW$12345", Address="Rue de Bruxelles", City="LLN", PostCode="2000", Country="Belgium", BirthDate=DateTime.Parse("2005-09-01"), BirthCity="LLN", PhoneNumber="0032477889922", Sexe="M",Role=Role.User },
            new User{FirstName="Carson",LastName="Alexander",UserName= "Caal", EmailAdress="Carson.Alexander@hotmail.com", Password="PW$123456", Address="Rue de Bruxelles", City="LLN", PostCode="2000", Country="Belgium", BirthDate=DateTime.Parse("2005-09-01"), BirthCity="LLN", PhoneNumber="0032477889922", Sexe="M",Role=Role.Premium },
            new User{FirstName="Carson",LastName="Alexander",UserName= "Caal", EmailAdress="Carson.Alexander@hotmail.com", Password="PW$123456", Address="Rue de Bruxelles", City="LLN", PostCode="2000", Country="Belgium", BirthDate=DateTime.Parse("2005-09-01"), BirthCity="LLN", PhoneNumber="0032477889922", Sexe="M",Role=Role.Invited }
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();

            var plans = new Plan[]
            {
            new Plan{Name="Tabata session Legs 01",SchreduledTimes=new List<SchreduledPlan>{ new SchreduledPlan()},Description="This session a focused on cardio hit and full legs exercices"},
            };
            foreach (Plan c in plans)
            {
                context.Plans.Add(c);
            }
            context.SaveChanges();

            var chronos = new Chrono[]
            {
            new Chrono{TimeInSecond=45},
            };
            foreach (Chrono e in chronos)
            {
                context.Chronos.Add(e);
            }
            context.SaveChanges();
        }
    }
}