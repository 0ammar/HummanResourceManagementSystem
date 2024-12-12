using HummanResourceManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HummanResourceManagementSystem.EntityCongigurations
{
    public class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
    {
        // primary key 

        //not null

        //unique 

        //default 

        //check

        //index

        //forigen key (relationships)
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //manage  table constanrints and configuration 
            //1- Set Table Name
            builder.ToTable("Departments");
            //Set Primary Key 
            builder.HasKey(x => x.Id);
            //Set Identity 
            builder.Property(x=>x.Id).UseIdentityColumn();
            //Not Null 
            builder.Property(x => x.NameAr).IsRequired(false);
            builder.Property(x => x.Image).IsRequired(false);
            //Length 
            builder.Property(x => x.NameAr).HasMaxLength(50);
            builder.Property(x => x.NameEn).HasMaxLength(50);
            //Nvarchar Mapluation
            builder.Property(x => x.NameEn).IsUnicode(false);
            builder.Property(x => x.Image).IsUnicode(false);
            //default
            builder.Property(x=>x.IsActive).HasDefaultValue(true);
            //builder.Property(x => x.CreationDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
            //unique 
            builder.HasIndex(x => x.NameAr).IsUnique(true);
            builder.HasIndex(x => x.NameEn).IsUnique(true);
            //check constraint
            builder.ToTable(x => x.HasCheckConstraint("CH_NameAr_Length", "Len(NameEn) >= 3"));
            //Relationships
            builder.HasMany<Person>().WithOne().HasForeignKey(x => x.DepartmentId).OnDelete(DeleteBehavior.NoAction); ;
        }
    }
}
