using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadSpringRolodexProject.Core.Models
{
    public class BranchLocationModel
    {
        public virtual int BranchLocationId { get; protected set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }

        public static BranchLocationModel Create(int branchLocationId, string city, string state)
        {
            return new BranchLocationModel
            {
                BranchLocationId = branchLocationId,
                City = city,
                State = state
            };
        }
    }
}
