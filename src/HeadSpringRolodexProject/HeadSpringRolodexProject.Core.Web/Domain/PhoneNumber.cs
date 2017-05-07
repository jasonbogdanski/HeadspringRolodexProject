namespace HeadSpringRolodexProject.Core.Web.Domain
{
    public enum PhoneNumberType { Home, Mobile, Other };
    public class PhoneNumber : IEntity
    {
        public virtual int Id { get; set; }
        public virtual PhoneNumberType PhoneType { get; set; }
        public virtual string Number { get; set; }

        public static PhoneNumber Create(int phoneNumberId, PhoneNumberType phoneType, string number)
        {
            return new PhoneNumber
            {
                Id = phoneNumberId,
                PhoneType = phoneType,
                Number = number
            };
        }
    }
}
