using System;

namespace Business.Entities
{
    public class PersonPhone : Entity
    {
        public string PhoneNumber { get; set; }

        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public Guid PhoneNumberTypeId { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
