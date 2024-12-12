using HummanResourceManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HummanResourceManagementSystem.EntityCongigurations
{
    public class LookupTypeEntityConfiguration : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.ToTable("LookupTypes");
            //Set Primary Key 
            builder.HasKey(x => x.Id);
            //Set Identity 
            //builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");

            //Allow Arabics 
            builder.Property(x=>x.NameAr).IsUnicode(true);

            //Check 
            builder.ToTable(x => x.HasCheckConstraint("CH_NameAr_Length", "Len(Name) >= 2"));
            builder.ToTable(x => x.HasCheckConstraint("CH_Name_Length", "Len(NameAr) >= 2"));
            //RelationShips
            builder.HasMany<LookupItem>().WithOne().HasForeignKey(x => x.LookupTypeId);
        }
    }
}
