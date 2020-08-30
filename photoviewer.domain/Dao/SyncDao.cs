using photoviewer.core.Data;
using SQLite;
using System;

namespace photoviewer.Domain.Dao
{
    public class SyncDao : IEntity
    {
        [PrimaryKey]
        public string Id { get; set; }

        public DateTime FirstSync { get; set; }

        public int Count { get; set; }
    }
}
