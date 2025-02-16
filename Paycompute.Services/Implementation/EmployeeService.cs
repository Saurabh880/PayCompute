using Paycompute.Entity;
using Paycompute.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycompute.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Employee newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(int EmployeeId)
        {
            var employee = GetById(EmployeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAllEmployees() => _context.Employees;

        public async Task UpdateAsync(Employee Employee)
        {
            _context.Update(Employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employeeByID = GetById(id);
            _context.Update(employeeByID);
            await _context.SaveChangesAsync();
        }
        public Employee GetById(int EmployeeId) => 
            _context.Employees.Where(e => e.Id == EmployeeId).FirstOrDefault();

        public decimal StudenLoanRepaymentAmount(int id, decimal TotalAmount)
        {
            throw new NotImplementedException();
        }

        public decimal UnionFees(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
