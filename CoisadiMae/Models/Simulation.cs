using SQLiteNetExtensions.Attributes;

namespace CoisadiMae.Models
{
    public class Simulation : BaseEntity
    {
        public int MomId { get; set; }

        public bool SocialSecurity { get; set; }
        public decimal SocialSecurityAmout { get; set; }

        public bool LifeInsurance { get; set; }
        public bool LifeInsuranceAmout { get; set; }

        public int Points { get; set; }
    }
}