namespace HeadSpringRolodexProject.Core.Web.Models
{
    public class BranchLocation
    {
        public virtual int BranchLocationId { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }

        public static BranchLocation Create(int branchLocationId, string city, string state)
        {
            return new BranchLocation
            {
                BranchLocationId = branchLocationId,
                City = city,
                State = state
            };
        }
    }
}
