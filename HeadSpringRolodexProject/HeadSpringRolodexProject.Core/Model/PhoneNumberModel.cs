using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadSpringRolodexProject.Core.Model
{
    public enum PhoneNumberType { Home, Mobile, Other };
    public class PhoneNumberModel
    {
        public virtual int PhoneNumberId { get; protected set; }
        public virtual PhoneNumberType PhoneType { get; set; }
        public virtual string Number { get; set; }
    }
}
