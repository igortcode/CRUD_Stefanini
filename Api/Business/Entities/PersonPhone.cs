using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class PersonPhone : Entity
    {
        public string PhoneNumber { get; set; }

        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
