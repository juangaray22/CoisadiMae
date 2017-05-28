using SQLite;

namespace CoisadiMae.DependencyServices
{
    public interface ISQLite
    {
        SQLiteConnection GetConn();
    }
}