using photoviewer.core.Data;
using SQLite;
using System;


namespace photoviewer.Domain.Dao
{
   public  class PhotoDao : IEntity
    {
        [PrimaryKey]
        public string Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public int Likes { get; set; }

        public bool LikedByUser { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }
    }
}
