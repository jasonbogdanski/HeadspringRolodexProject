namespace HeadSpringRolodexProject.Core.Web.Domain
{
    public enum PhoneNumberType { Home, Mobile, Other };
    public class PhoneNumber
    {
        public virtual int PhoneNumberId { get; set; }
        public virtual PhoneNumberType PhoneType { get; set; }
        public virtual string Number { get; set; }

        public static PhoneNumber Create(int phoneNumberId, PhoneNumberType phoneType, string number)
        {
            return new PhoneNumber
            {
                PhoneNumberId = phoneNumberId,
                PhoneType = phoneType,
                Number = number
            };
        }
    }
}
