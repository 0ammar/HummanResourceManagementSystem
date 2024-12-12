namespace HummanResourceManagementSystem.Entities
{
    public class EmployeeContract : MainEntity
    {
        public DateOnly StartingDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? DurationInYears { get; set; }
        public int? PositionTypeId { get; set; }
        public int? ContractTypeId { get; set; }
        public string Title { get; set; }
        public float Salary { get; set; }
        public List<string> Conditions { get; set; }
        public List<string> Responsibility { get; set; }
        public string Heading { get; set; }
        public int PersonId { get; set; }
    }
}
