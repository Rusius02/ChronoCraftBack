namespace Infrastructure.SqlServer.Repository.User
{
    public partial class UserRepository
    {
        public const string TableName = "users",
            ColId = "id",
            ColLastName = "lastName",
            ColFirstName = "firstName",
            ColUserName = "userName",
            ColEmailAddress = "emailAdress",
            ColPassword = "password",
            ColAddress = "address",
            ColCity = "city",
            ColPostcode = "postCode",
            ColCountry = "country",
            ColBirthdate = "birthdate",
            ColBirthcity = "birthcity",
            ColPhoneNumber = "phoneNumber",
            ColSexe = "sexe",
            ColRole = "role",
            ColNationality = "nationality";
    
        //We have all our queries here 
        //Create query which creates a database User
        public static readonly string ReqCreate = $@"
        INSERT INTO {TableName}({ColLastName}, {ColFirstName}, {ColUserName},
        {ColEmailAddress},{ColPassword},{ColAddress}, {ColCity}, {ColPostcode},
        {ColCountry},{ColBirthdate}, {ColBirthcity}, {ColPhoneNumber}, {ColSexe},
        {ColRole}, {ColNationality})
        OUTPUT INSERTED.{ColId}
        VALUES(@{ColLastName}, @{ColFirstName},   
        @{ColUserName}, @{ColEmailAddress} ,@{ColPassword}, @{ColAddress}, @{ColCity},
        @{ColPostcode}, @{ColCountry}, @{ColBirthdate}, @{ColBirthcity},
        @{ColPhoneNumber}, @{ColSexe}, @{ColRole}, @{ColNationality})";

        //This is the one that will send us all the User
        public static readonly string ReqGetAll = $@"
        SELECT * FROM {TableName}";

        //This is the one that will send us all the activities based on Id
        public static readonly string ReqGetById = $@"
        SELECT * FROM {TableName}
        WHERE {ColId} = @{ColId}";
        
        //Delete query which deletes the data based on the id
        public static readonly string ReqDelete = $@"
            DELETE FROM {TableName} WHERE {ColId} = @{ColId}";

        // The Update request which allows to modify a user in the database
        public static readonly string ReqUpdate = $@"
            UPDATE {TableName}
            SET {ColFirstName} = @{ColFirstName}, 
            {ColLastName} = @{ColLastName},
            {ColUserName} = @{ColUserName},
            {ColEmailAddress} = @{ColEmailAddress},
            {ColPassword} = @{ColPassword}, 
            {ColAddress} = @{ColAddress}, 
            {ColCity} = @{ColCity}, 
            {ColPostcode} = @{ColPostcode}, 
            {ColCountry} = @{ColCountry}, 
            {ColBirthdate} = @{ColBirthdate},
            {ColBirthcity} = @{ColBirthcity}, 
            {ColPhoneNumber} = @{ColPhoneNumber}, 
            {ColSexe} = @{ColSexe},
            {ColRole} = @{ColRole},
            {ColNationality} = @{ColNationality}
            WHERE {ColId} = @{ColId}";
        
        //This is the one that will send us all the activities based on Pseudo et Password
        public static readonly string ReqGetByPseudo = $@"
        SELECT * FROM {TableName}
        WHERE {ColUserName} = @{ColUserName} AND {ColPassword} = @{ColPassword}";
            
    }
}