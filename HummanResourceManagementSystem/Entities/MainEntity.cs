namespace HummanResourceManagementSystem.Entities
{
    public class MainEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
