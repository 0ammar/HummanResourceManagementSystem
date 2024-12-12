using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HummanResourceManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class ImplemetDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.CheckConstraint("CH_NameAr_Length", "Len(NameEn) >= 3");
                });

            migrationBuilder.CreateTable(
                name: "LookupTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupTypes", x => x.Id);
                    table.CheckConstraint("CH_Name_Length1", "Len(NameAr) >= 2");
                    table.CheckConstraint("CH_NameAr_Length2", "Len(Name) >= 2");
                });

            migrationBuilder.CreateTable(
                name: "LookupItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LookupTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupItems", x => x.Id);
                    table.CheckConstraint("CH_Name_Length", "Len(NameAr) >= 2");
                    table.CheckConstraint("CH_NameAr_Length1", "Len(Name) >= 2");
                    table.ForeignKey(
                        name: "FK_LookupItems_LookupTypes_LookupTypeId",
                        column: x => x.LookupTypeId,
                        principalTable: "LookupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalSSNID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalityId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    UserTypeId = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentityImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_LookupItems_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "LookupItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persons_LookupItems_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "LookupItems",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DurationInYears = table.Column<int>(type: "int", nullable: true),
                    PositionTypeId = table.Column<int>(type: "int", nullable: true),
                    ContractTypeId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false),
                    Conditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsibility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Heading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_LookupItems_ContractTypeId",
                        column: x => x.ContractTypeId,
                        principalTable: "LookupItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_LookupItems_PositionTypeId",
                        column: x => x.PositionTypeId,
                        principalTable: "LookupItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "LookupTypes",
                columns: new[] { "Id", "ModificationDate", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, null, "Nationality", "الجنسية" },
                    { 2, null, "ContractType", "نوع العقد" },
                    { 3, null, "PositionTypeId", "المسمى الوظيفي" },
                    { 4, null, "UserType", "نوع المستخدم" }
                });

            migrationBuilder.InsertData(
                table: "LookupItems",
                columns: new[] { "Id", "LookupTypeId", "ModificationDate", "Name", "NameAr" },
                values: new object[,]
                {
                    { 1, 1, null, "Jordanian", "اردني" },
                    { 2, 1, null, "palestinian", "فلسطيني" },
                    { 3, 1, null, "Egyption", "مصري" },
                    { 4, 2, null, "Full Time", "دوام كامل" },
                    { 5, 2, null, "Part Time", "دوام جزئي" },
                    { 6, 3, null, "Sales and Marketing", "مبيعات وتسويق" },
                    { 7, 3, null, "Finance and Accounting", "مالية ومحاسبة" },
                    { 8, 3, null, "Administrative", "اداري" },
                    { 9, 4, null, "Employee", "موظف" },
                    { 10, 4, null, "Admin", "مدير" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "BirthDate", "CreationDate", "DepartmentId", "Email", "FirstName", "IdentityImagePath", "InterviewDate", "IsActive", "LastName", "MiddleName", "ModificationDate", "NationalSSNID", "NationalityId", "Password", "PersonalImagePath", "Phone", "ResumePath", "UserTypeId" },
                values: new object[] { 1, new DateOnly(1997, 7, 17), new DateTime(2024, 10, 21, 19, 50, 31, 256, DateTimeKind.Local).AddTicks(1398), null, "6A2CFE66D92200086FDC37D2E4B656759DEB45E76B6A78E2F3EBF338C573EB539BFCDA3DE7F09495DCF48D987F2BA2F1", "Admin", "", new DateTime(2024, 10, 21, 19, 50, 31, 256, DateTimeKind.Local).AddTicks(1412), true, "Account", "Default", null, "12345", 1, "E58DF53ED3BC705D5B921BA27A6101B88380F0FABAC71A1DF84834254E1F1B31D7A7700C4388E36F0F76B9148D90985B", "", "", "", 10 });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ContractTypeId",
                table: "Contracts",
                column: "ContractTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PersonId",
                table: "Contracts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PositionTypeId",
                table: "Contracts",
                column: "PositionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_NameAr",
                table: "Departments",
                column: "NameAr",
                unique: true,
                filter: "[NameAr] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_NameEn",
                table: "Departments",
                column: "NameEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LookupItems_LookupTypeId",
                table: "LookupItems",
                column: "LookupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_DepartmentId",
                table: "Persons",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_NationalityId",
                table: "Persons",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_UserTypeId",
                table: "Persons",
                column: "UserTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "LookupItems");

            migrationBuilder.DropTable(
                name: "LookupTypes");
        }
    }
}
