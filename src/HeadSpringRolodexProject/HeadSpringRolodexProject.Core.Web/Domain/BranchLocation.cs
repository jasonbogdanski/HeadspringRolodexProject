namespace HeadSpringRolodexProject.Core.Web.Domain
{
    public class BranchLocation : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }

        public static BranchLocation Create(int branchLocationId, string city, string state)
        {
            return new BranchLocation
            {
                Id = branchLocationId,
                City = city,
                State = state
            };
        }
    }
}
