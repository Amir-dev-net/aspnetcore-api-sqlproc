using aspnetcore_api_sqlproc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_api_sqlproc.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("by-department/{deptId}/status/{isActive}")]
        public async Task<IActionResult> GetByDeptAndStatus(int deptId, bool isActive)
        {
            var employees = await _employeeService.GetEmployeesAsync(deptId, isActive);
            return Ok(employees);
        }

        [HttpGet("multi-result")]
        public async Task<IActionResult> GetMultiResult()
        {
            var result = await _employeeService.GetEmployeeDepartmentDataAsync();
            return Ok(result);
        }
    }

}
