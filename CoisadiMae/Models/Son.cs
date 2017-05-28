using SQLiteNetExtensions.Attributes;

namespace CoisadiMae.Models
{
    public class Son : BaseEntity
    {
        public string Name { get; set; }
               
      //  public Mom Mom { get; set; }

        [ForeignKey(typeof(Mom))]
        public int MomId { get; set; }
    }
}