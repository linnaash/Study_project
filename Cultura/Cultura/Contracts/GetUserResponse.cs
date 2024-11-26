namespace Cultura.Contracts.Employee
{
    public class GetUserResponse
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? DepartmentId { get; set; }
    }
}
