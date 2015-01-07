using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using HeadSpringRolodexProject.Core.Models;

namespace HeadSpringRolodexProject.DataAccessLayer.NHibernate.Mappings
{
    public class BranchLocationModelMapping : ClassMap<BranchLocationModel>
    {
        public BranchLocationModelMapping()
        {
            Id(x => x.BranchLocationId).GeneratedBy.Native();
            Map(x => x.City).Length(50).Not.Nullable();
            Map(x => x.State).Length(50).Not.Nullable();
            Table("BranchLocation");
        }
    }
}
