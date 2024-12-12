using HummanResourceManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HummanResourceManagementSystem.EntityCongigurations
{
    public class LookupItemEntityTypeConfiguration : IEntityTypeConfiguration<LookupItem>
    {
        public void Configure(EntityTypeBuilder<LookupItem> builder)
        {
            builder.ToTable("LookupItems");
            builder.HasKey(x => x.Id);
            //Set Identity 
            //builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");

            //Allow Arabics 
            builder.Property(x => x.NameAr).IsUnicode(true);
            builder.Property(x => x.Name).IsUnicode(false);
            //Check 
            builder.ToTable(x => x.HasCheckConstraint("CH_NameAr_Length", "Len(Name) >= 2"));
            builder.ToTable(x => x.HasCheckConstraint("CH_Name_Length", "Len(NameAr) >= 2"));
            //Relationships
            builder.HasMany<Person>().WithOne().HasForeignKey(x => x.UserTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<Person>().WithOne().HasForeignKey(x => x.NationalityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<EmployeeContract>().WithOne().HasForeignKey(x => x.ContractTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany<EmployeeContract>().WithOne().HasForeignKey(x => x.PositionTypeId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
