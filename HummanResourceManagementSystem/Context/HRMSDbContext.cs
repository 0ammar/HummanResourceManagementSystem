

using HummanResourceManagementSystem.Entities;
using HummanResourceManagementSystem.EntityCongigurations;
using HummanResourceManagementSystem.Helper;
using Microsoft.EntityFrameworkCore;

namespace HummanResourceManagementSystem.Context
{
    public class HRMSDbContext : DbContext
    {
        //Tables 
        public DbSet<Department> Departments { get; set; }
        public DbSet<LookupType> LookupTypes { get; set; }
        public DbSet<LookupItem> LookupItems { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<EmployeeContract> Contracts { get; set; }
        public HRMSDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<LookupType>().HasData(
           new LookupType { Id = 1, Name = "Nationality", NameAr = "الجنسية" },
           new LookupType { Id = 2, Name = "ContractType", NameAr = "نوع العقد" },
           new LookupType { Id = 3, Name = "PositionTypeId", NameAr = "المسمى الوظيفي" },
           new LookupType { Id = 4, Name = "UserType", NameAr = "نوع المستخدم" });

            modelBuilder.Entity<LookupItem>().HasData(
            new LookupItem { Id = 1, Name = "Jordanian", NameAr = "اردني", LookupTypeId = 1 },
            new LookupItem { Id = 2, Name = "palestinian", NameAr = "فلسطيني", LookupTypeId = 1 },
            new LookupItem { Id = 3, Name = "Egyption", NameAr = "مصري", LookupTypeId = 1 },
            new LookupItem { Id = 4, Name = "Full Time", NameAr = "دوام كامل", LookupTypeId = 2 },
            new LookupItem { Id = 5, Name = "Part Time", NameAr = "دوام جزئي", LookupTypeId = 2 },
            new LookupItem { Id = 6, Name = "Sales and Marketing", NameAr = "مبيعات وتسويق", LookupTypeId = 3 },
            new LookupItem { Id = 7, Name = "Finance and Accounting", NameAr = "مالية ومحاسبة", LookupTypeId = 3 },
            new LookupItem { Id = 8, Name = "Administrative", NameAr = "اداري", LookupTypeId = 3 },
            new LookupItem { Id = 9, Name = "Employee", NameAr = "موظف", LookupTypeId = 4 },
            new LookupItem { Id = 10, Name = "Admin", NameAr = "مدير", LookupTypeId = 4 });

            modelBuilder.Entity<Person>().HasData(
                new Person { Id=1,FirstName = "Admin",
                 MiddleName="Default",
                 LastName="Account"
                ,BirthDate = DateOnly.Parse("1997-07-17"),
                Email = EncryptionHelper.GenerateSHA384String("admin@mangohr.com"),
                Password = EncryptionHelper.GenerateSHA384String("123qwe"),
                CreationDate = DateTime.Now,
                IdentityImagePath = "",
                InterviewDate = DateTime.Now,
                IsActive = true,DepartmentId = null,
                ModificationDate = null,
                NationalityId=1,
                NationalSSNID ="12345",
                PersonalImagePath="",
                Phone ="",
                ResumePath="",
                UserTypeId= 10
                });
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LookupTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LookupItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContractEntityTypeConfiguration());
           

            

        }

    }
}
