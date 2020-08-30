using photoviewer.core.Data;
using SQLite;

namespace photoviewer.Domain.Dao
{
    public class UserImageUrlDao : IEntity
    {
        [PrimaryKey]
        public string Id { get; set; }

        public string Small { get; set; }

        public string Medium { get; set; }

        public string Large { get; set; }
    }
}
