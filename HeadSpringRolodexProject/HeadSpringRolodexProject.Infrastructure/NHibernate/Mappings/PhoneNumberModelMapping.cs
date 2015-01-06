using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using HeadSpringRolodexProject.Core.Models;

namespace HeadSpringRolodexProject.DataAccessLayer.NHibernate.Mappings
{
    public class PhoneNumberModelMapping:ClassMap<PhoneNumberModel>
    {
        public PhoneNumberModelMapping()
        {
            Id(x => x.PhoneNumberId).GeneratedBy.Native();
            Map(x => x.Number).Length(100).Not.Nullable();
            Map(x => x.PhoneType).CustomType<int>();
            Table("PhoneNumber");
        }
    }
}
