using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;

namespace HummanResourceManagementSystem.Entities
{
    public class Person : MainEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string NationalSSNID { get; set; }
        public int? NationalityId { get; set; }
        public int? DepartmentId { get; set; }
        public int? UserTypeId { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Password { get; set; }
        public string PersonalImagePath { get; set; }
        public string ResumePath { get; set; }
        public string IdentityImagePath { get; set; }
        
    }
}
