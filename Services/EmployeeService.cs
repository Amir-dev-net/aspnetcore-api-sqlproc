using aspnetcore_api_sqlproc.Data;
using aspnetcore_api_sqlproc.Models;
using Microsoft.EntityFrameworkCore;

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

    }

}
