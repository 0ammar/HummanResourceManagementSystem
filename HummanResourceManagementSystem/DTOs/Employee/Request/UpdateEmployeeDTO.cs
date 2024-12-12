namespace HummanResourceManagementSystem.DTOs.Employee.Request
{
    public class UpdateEmployeeDTO
    {
        public int  Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? NationalityId { get; set; }
        public string NationalSSNID { get; set; }
        public int? DepartmentId { get; set; }
        public DateOnly BirthDate { get; set; }
    }
}
