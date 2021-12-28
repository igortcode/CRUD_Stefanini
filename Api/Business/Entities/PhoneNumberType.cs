using System;
using System.Collections.Generic;

namespace Business.Entities
{
    public class PhoneNumberType : Entity
    {
        public string Name { get; set; }
        public Guid PersonPhoneId { get; set; }
        public List<PersonPhone> PersonPhones { get; set; }
    }
}
