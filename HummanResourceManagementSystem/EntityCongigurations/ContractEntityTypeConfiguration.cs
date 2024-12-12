using HummanResourceManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Contracts;

namespace HummanResourceManagementSystem.EntityCongigurations
{
    public class ContractEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeContract>
    {
        public void Configure(EntityTypeBuilder<EmployeeContract> builder)
        {
            builder.ToTable("Contracts");
            //Set Primary Key 
            builder.HasKey(x => x.Id);
            //Set Identity 
            builder.Property(x => x.Id).UseIdentityColumn();
            //Default Values
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.CreationDate).HasDefaultValueSql("getdate()");
        }
    }
}
