using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using HeadSpringRolodexProject.Core.Models;

namespace HeadSpringRolodexProject.DataAccessLayer.NHibernate.Mappings
{
    public class EmployeeModelMapping: ClassMap<EmployeeModel>
    {
        public EmployeeModelMapping()
        {
            Id(x => x.EmployeeId).GeneratedBy.Native();
            Map(x => x.FistName).Length(50).Not.Nullable();
            Map(x => x.LastName).Length(50).Not.Nullable();
            HasOne(x => x.BranchLocation);
            HasMany(x => x.PhoneNumbers).KeyColumn("Id");
            Map(x => x.Email).Length(100).Not.Nullable();
            Map(x => x.JobTitle).Length(50).Not.Nullable();
            Table("Employee");
        }
    }
}
