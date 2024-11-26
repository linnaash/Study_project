namespace Cultura.Contracts.Employee
{
    public class CreateOrUpdateUserRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int? DepartmentId { get; set; }
    }
}

