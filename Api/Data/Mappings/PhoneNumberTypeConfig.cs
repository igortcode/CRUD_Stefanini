using Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class PhoneNumberTypeConfig : IEntityTypeConfiguration<PhoneNumberType>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberType> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();
            
            //builder.HasMany(p => p.PersonPhones)
            //    .WithOne(pp => pp.PhoneNumberType)
            //    .HasForeignKey(pp => pp.Id);

            builder.ToTable("PhoneNumberType");

        }
    }
}
