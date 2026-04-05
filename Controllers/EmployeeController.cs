using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyFirstApi.Models;
using System.Data;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("/api/employees")]
    public class EmployeeController : ControllerBase
    {
        //public string connStr = "Data Source=Nazarbek\\MSSQLSERVER01;Initial Catalog=NorthWindDb;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
        public IDbConnection connection = new SqlConnection("Data Source=Nazarbek\\MSSQLSERVER01;Initial Catalog=NorthWindDb;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");


        // Gett All Employees
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            string query = "SELECT EmployeeID, FirstName, LastName, BirthDate, City FROM Employees;";
            IEnumerable<Employee> employees = await connection.QueryAsync<Employee>(query);
            return employees;
        }


        // Get Employee By Id
        [HttpGet]
        [Route("{id}")]
        public async Task<Employee> GetEmployeeByID(int id)
        {
            string query = "SELECT EmployeeID, FirstName, LastName, BirthDate, City FROM Employees WHERE EmployeeID = @Id;";
            Employee? employee = await connection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = id });
            return employee;
        }

        // Add Employee
        [HttpPost]
        public async Task<bool> AddEmployee(Employee employee)
        {
            string query = "INSERT INTO Employees(FirstName, LastName, BirthDate, City) VALUES(@FirstName, @LastName, @BirthDate, @City);";
            int rowsAffected = await connection.ExecuteAsync(query,employee);
            if (rowsAffected > 0) return true;
            else return false;
        }

        // Update Employee
        [HttpPut("{id}")]
        public async Task<bool> UpdateEmployeeByID(int id, Employee employee)
        {
            string query = "update Employees set FirstName = @FirstName, Lastname = @LastName, BirthDate = @BirthDate, City = @City where EmployeeID = @EmployeeID;";
            int rowsAffected = await connection.ExecuteAsync(query, employee);
            if (rowsAffected > 0) return true;
            else return false;
        }

        // Detele Employee
        [HttpDelete("{id}")]
        public async Task<bool> DeleteEmployeeById(int id)
        {
            string query = "DELETE FROM Employees WHERE EmployeeID = @Id";
            int rowsAffected = await connection.ExecuteAsync(query, new { Id = id });
            if (rowsAffected > 0) return true;
            else return false;
        }
    }
}
