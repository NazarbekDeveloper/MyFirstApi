using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyFirstApi.Data;
using MyFirstApi.Models;
using MyFirstApi.Services;
using System.Data;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("/api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }
        // Gett All Employees
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _employeeService.GetAllEmployeesAsync();
        }


        // Get Employee By Id
        [HttpGet]
        [Route("{id}")]
        public async Task<Employee> GetEmployeeByID(int id)
        {      
            return await _employeeService.GetEmployeeByIdAsync(id);
        }

        // Add Employee
        [HttpPost]
        public Task<bool> AddEmployee(Employee employee)
        {
            return _employeeService.CreateEmployeeAsync(employee);
        }

        // Update Employee
        [HttpPut("{id}")]
        public async Task<bool> UpdateEmployeeByID(int id, Employee employee)
        {
            return await _employeeService.UpdateEmployeeAsync(employee);
        }

        // Detele Employee
        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployeeById(int id)
        {
            return await _employeeService.DeleteEmployeeAsync(id);
        }
    }
}
