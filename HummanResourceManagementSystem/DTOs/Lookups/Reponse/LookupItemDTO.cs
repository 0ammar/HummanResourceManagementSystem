namespace HummanResourceManagementSystem.DTOs.Lookups.Reponse
{
    public class LookupItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string ParentNameEn { get; set; }
        public string ParentNameAr { get; set; }
        public string CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
