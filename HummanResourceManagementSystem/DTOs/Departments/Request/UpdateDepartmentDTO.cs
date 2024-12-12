namespace HummanResourceManagementSystem.DTOs.Departments.Request
{
    public class UpdateDepartmentDTO
    {
        public int Id { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? Image { get; set; }
        public bool? IsActive { get; set; }
    }
}
