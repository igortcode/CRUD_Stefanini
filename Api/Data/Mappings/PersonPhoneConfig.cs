using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class PersonPhoneConfig : IEntityTypeConfiguration<PersonPhone>
    {
        public void Configure(EntityTypeBuilder<PersonPhone> builder)
        {
            builder.HasKey(pp => pp.Id);
            
            builder.Property(pp => pp.PhoneNumber)
                .HasMaxLength(30)
                .IsRequired();

            builder.HasOne(pp => pp.Person)
                .WithMany(p => p.Phones)
                .HasForeignKey(pp => pp.PersonId);

            builder.HasOne(pp => pp.PhoneNumberType);
                
            
            builder.ToTable("PersonPhone");
        }
    }
}
