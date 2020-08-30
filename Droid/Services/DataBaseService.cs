using System.IO;
using photoviewer.core.Services;
using SQLite;

namespace photoviewer.Droid.Services
{
    public class DataBaseService : IDataBaseService
    {
        /// <summary>
        /// Подключение с базой данных
        /// </summary>
        public SQLiteConnection GetConnection(string dbName)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbName);

            if (!File.Exists(path))
                // ReSharper disable once ObjectCreationAsStatement
                new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

            return new SQLiteConnection(path);
        }
    }
}
