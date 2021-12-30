using Business.Entities;
using Business.Interfaces.Repository;
using Data.Context;

namespace Data.Repository
{
    public class PhoneNumberTypeRepository : GenericRepository<PhoneNumberType>, IPhoneNumberTypeRepository
    {
        private readonly ApiDbContext _context;
        public PhoneNumberTypeRepository(ApiDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
