using System.Collections.Generic;

namespace Business.Entities
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public ICollection<PersonPhone> Phones { get; set; }
    }
}
