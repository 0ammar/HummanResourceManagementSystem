namespace HummanResourceManagementSystem.Entities
{
    public class LookupItem : MainEntity
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int LookupTypeId { get; set; } //forigen key for Lookup Type Table 
    }
}
