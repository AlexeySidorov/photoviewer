using SQLite;

namespace photoviewer.core.Services
{
    public interface IDataBaseService
    {
        /// <summary>
        /// Подключение с базой данных
        /// </summary>
        SQLiteConnection GetConnection(string dbName);
    }
}
