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
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            var result =  await _employeeService.GetAllEmployeesAsync();
            return Ok(result);
        }


        // Get Employee By Id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeByID(int id)
        {      
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(result);
        }

        // Add Employee
        [HttpPost]
        public async Task<ActionResult<bool>> AddEmployee(Employee employee)
        {
            var result = await _employeeService.CreateEmployeeAsync(employee);
            return (result)? Ok(result) : BadRequest("Employee qo'shishda xatolik yuz berdi");
        }

        // Update Employee
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateEmployeeByID(int id, Employee employee)
        {
            var result = await _employeeService.UpdateEmployeeAsync(employee);
            return (result) ? Ok(result) : BadRequest("Employee yangilashda xatolik yuz berdi");
        }

        // Detele Employee
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEmployeeById(int id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            return (result) ? Ok(result) : BadRequest("Employee o'chirishda xatolik yuz berdi");
        }
    }
}
