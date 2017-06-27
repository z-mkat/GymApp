using SQLite;
namespace GymApp
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
