using photoviewer.core.Data;
using SQLite;
using System;
namespace photoviewer.Domain.Dao
{
    public class UserDao : IEntity
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }
    }
}
