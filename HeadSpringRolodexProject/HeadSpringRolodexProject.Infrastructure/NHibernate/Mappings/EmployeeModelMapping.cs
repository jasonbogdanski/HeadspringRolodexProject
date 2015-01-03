using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using HeadSpringRolodexProject.Core.Model;

namespace HeadSpringRolodexProject.Infrastructure.NHibernate.Mappings
{
    public class EmployeeModelMapping: ClassMap<EmployeeModel>
    {
        public EmployeeModelMapping()
        {
            Id(x => x.Id);
            Map(x => x.FistName).Length(50).Not.Nullable();
            Map(x => x.LastName).Length(50).Not.Nullable();
            Map(x => x.Location).Length(100).Not.Nullable();
            Map(x => x.HomeNumber).Length(100);
            Map(x => x.MobileNumber).Length(100);
            Map(x => x.Email).Length(100).Not.Nullable();
            Map(x => x.JobTitle).Length(50).Not.Nullable();
            Table("Employee");
        }
    }
}
