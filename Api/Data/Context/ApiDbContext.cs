using Business.Entities;
using Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<PersonPhone> PeoplePhones { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }

        public ApiDbContext(DbContextOptions options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PersonPhoneConfig());
            modelBuilder.ApplyConfiguration(new PhoneNumberTypeConfig());
        }
    }
}
