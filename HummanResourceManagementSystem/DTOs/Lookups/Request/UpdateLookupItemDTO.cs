namespace HummanResourceManagementSystem.DTOs.Lookups.Request
{
    public class UpdateLookupItemDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public bool? IsActive { get; set; }
    }
}
