namespace Infrastructure.SqlServer.Repository.User
{
    public interface IJwtAuthentificationManager
    {
        string Authentificate(string pseudo, string password);
    }
}