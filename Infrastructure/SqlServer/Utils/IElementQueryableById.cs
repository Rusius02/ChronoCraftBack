namespace Infrastructure.SqlServer.Utils
{
    public interface IElementQueryableById<out T>
    {
        T GetById(int id);
    }
}