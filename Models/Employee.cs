namespace aspnetcore_api_sqlproc.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }

}
