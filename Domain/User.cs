﻿using System.Net.Mail;

namespace Domain
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAdress { get  ; set ; }
        public string Password { get ; set ; }
        public string Address { get  ; set ; }
        public string City { get  ; set ; }
        public string PostCode { get ; set ; }
        public string Country { get  ; set ; }
        public DateTime BirthDate { get  ; set  ; }
        public string BirthCity { get  ; set ; }
        public string PhoneNumber { get  ; set ; }
        public string Sexe { get ; set ; }
        internal Nationality Nationality { get ; set ; }
        internal List<Plan> Plans { get ; set ; }
    }

    enum Nationality{
        Belgian,
        French,
        Britain,
        American,
        Argentin,
        Brasilian
    }
}