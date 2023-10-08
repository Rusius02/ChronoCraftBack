using System.Net.Mail;

namespace Domain
{
    public class User
    {
        private String firstName;
        private String lastName;
        private String userName;
        private MailAddress emailAdress;
        private String password;
        private String address;
        private String? city;
        private String? postCode;
        private String? country;
        private DateTime birthDate;
        private String? birthCity;
        private Nationality nationality;
        private String phoneNumber;
        private List<Plan> plans;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string UserName { get => userName; set => userName = value; }
        public MailAddress EmailAdress { get => emailAdress; set => emailAdress = value; }
        public string Password { get => password; set => password = value; }
        public string Adress { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string PostCode { get => postCode; set => postCode = value; }
        public string Country { get => country; set => country = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string BirthCity { get => birthCity; set => birthCity = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        internal Nationality Nationality { get => nationality; set => nationality = value; }
        internal List<Plan> Plans { get => plans; set => plans = value; }
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