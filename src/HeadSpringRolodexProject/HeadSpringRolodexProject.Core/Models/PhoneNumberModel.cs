using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadSpringRolodexProject.Core.Models
{
    public enum PhoneNumberType { Home, Mobile, Other };
    public class PhoneNumberModel
    {
        public virtual int PhoneNumberId { get; set; }
        public virtual PhoneNumberType PhoneType { get; set; }
        public virtual string Number { get; set; }

        public static PhoneNumberModel Create(int phoneNumberId, PhoneNumberType phoneType, string number)
        {
            return new PhoneNumberModel
            {
                PhoneNumberId = phoneNumberId,
                PhoneType = phoneType,
                Number = number
            };
        }
    }
}
