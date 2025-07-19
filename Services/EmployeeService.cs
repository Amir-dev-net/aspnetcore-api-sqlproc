using aspnetcore_api_sqlproc.Data;
using aspnetcore_api_sqlproc.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace aspnetcore_api_sqlproc.Services
{
    public class EmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetEmployeesAsync(int departmentId, bool isActive)
        {
            return await _context.Employees
                        .FromSqlInterpolated($"EXEC sp_GetEmployeesByDeptAndStatus @DepartmentId = {departmentId}, @IsActive = {isActive}")
                        .ToListAsync();
        }

        public async Task<EmployeeDepartmentResponse> GetEmployeeDepartmentDataAsync()
        {
            var response = new EmployeeDepartmentResponse
            {
                Employees = new List<Employee>(),
                Departments = new List<Department>()
            };

            using (var connection = _context.Database.GetDbConnection())
            {
                await connection.OpenAsync();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "GetEmployeeAndDepartment";
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // First result set: Employees
                        while (await reader.ReadAsync())
                        {
                            response.Employees.Add(new Employee
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }

                        // Move to next result set
                        await reader.NextResultAsync();

                        // Second result set: Departments
                        while (await reader.ReadAsync())
                        {
                            response.Departments.Add(new Department
                            {
                                DeptId = reader.GetInt32(0),
                                DeptName = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return response;
        }


    }

}
