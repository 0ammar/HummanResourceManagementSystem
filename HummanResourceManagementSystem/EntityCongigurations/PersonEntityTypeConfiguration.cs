using HummanResourceManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HummanResourceManagementSystem.EntityCongigurations
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            //Set Primary Key 
            builder.HasKey(x => x.Id);
            //Set Identity 
            builder.Property(x => x.Id).UseIdentityColumn();
            //Default Values
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            //Relation Ship 
            builder.HasMany<EmployeeContract>().WithOne().HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
