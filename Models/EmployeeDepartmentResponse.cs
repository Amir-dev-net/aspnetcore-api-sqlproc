namespace aspnetcore_api_sqlproc.Models
{
    public class EmployeeDepartmentResponse
    {
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }
    }
}
