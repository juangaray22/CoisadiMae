using SQLite;

namespace CoisadiMae.Models
{
    public class BaseEntity
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }
    }
}