using Dapper;
using MyFirstApi.Data;
using MyFirstApi.Models;
using System.Data;

namespace MyFirstApi.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        readonly ApplicationDbContext _context;
        private IDbConnection _connection;
        public EmployeeRepository(ApplicationDbContext appDbContext)
        {
            _context = appDbContext;
            this._connection = _context.GetConnection();
        }
        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            string query = "INSERT INTO Employees(FirstName, LastName, BirthDate, City) VALUES(@FirstName, @LastName, @BirthDate, @City);";
            int result = await _connection.ExecuteAsync(query, employee);     
            return result > 0;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            string query = "DELETE FROM Employees where EmployeeID = @Id";
            int rowsAffected = await _connection.ExecuteAsync(query, new { Id = id });
            return (rowsAffected > 0);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            string query = "SELECT EmployeeID, FirstName, LastName, BirthDate, City FROM Employees;";
            return await _connection.QueryAsync<Employee>(query); 
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            string query = "SELECT EmployeeID, FirstName, LastName, BirthDate, City FROM Employees WHERE EmployeeID = @Id;";
            return await _connection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = id });

        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            string query = "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, BirthDate = @BirthDate, City = @City WHERE EmployeeID = @EmployeeID;";
            int rowsAffected =  await _connection.ExecuteAsync(query, employee);
            return (rowsAffected > 0);
        }
    }
}
