using Business.Entities;
using Business.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PhoneNumberTypeRepository : GenericRepository<PhoneNumberType>, IPhoneNumberTypeRepository {}
}
