namespace HummanResourceManagementSystem.DTOs.Contract.Request
{
    public class CreateNewEmployeeDTO
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? NationalityId { get; set; }
        public string NationalSSNID { get; set; }
        public int? DepartmentId { get; set; }
        public DateOnly BirthDate { get; set; }
        public DateTime InterviewDate { get; set; }
        public string IdentityImagePath { get; set; }
        //Contract Data
        public DateOnly StartingDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? DurationInYears { get; set; }
        public int PositionTypeId { get; set; }
        public int ContractTypeId { get; set; }
        public string Title { get; set; }
        public float Salary { get; set; }
        public List<string> Conditions { get; set; }
        public List<string> Responsibility { get; set; }
        public string Heading { get; set; }

    }
}
