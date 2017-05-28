using SQLiteNetExtensions.Attributes;

namespace CoisadiMae.Models
{
    public class Son : BaseEntity
    {
        public string Name { get; set; }

        [ForeignKey(typeof(Mom))]
        public Mom Mom { get; set; }
        public int MomId { get; set; }
    }
}