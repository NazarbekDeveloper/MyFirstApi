using MyFirstApi.Models;
using MyFirstApi.Repositories;

namespace MyFirstApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            if (employee == null) return false;
            return await _employeeRepository.CreateEmployeeAsync(employee);
        }

        public Task<bool> DeleteEmployeeAsync(int id)
        {
            if (id == 0) throw new InvalidDataException("ID si 0 ga teng bo'lgan Employee mavjud emas");
            return _employeeRepository.DeleteEmployeeAsync(id);
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
             return _employeeRepository.GetAllEmployeesAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            if (id <= 0) throw new InvalidDataException("id nomusbat bo'lishi mumkun emas");
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            if (employee == null) throw new InvalidDataException(" Employee null bo'lolmaydi");
            return _employeeRepository.UpdateEmployeeAsync(employee);
        }
    }
}
