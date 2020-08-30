using photoviewer.core.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace photoviewer.Domain.Dao
{
    public class PhotoUrlDao : IEntity
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Raw { get; set; }
        public string Full { get; set; }
        public string Regular { get; set; }
        public string Small { get; set; }
        public string Thumb { get; set; }
    }
}
