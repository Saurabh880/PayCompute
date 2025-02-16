using Paycompute.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paycompute.Services
{
    public interface IEmployeeService
    {
        Task CreateAsync(Employee newEmployee); 
        Employee GetById (int EmployeeId);
        Task UpdateAsync(Employee Employee);
        Task UpdateAsync(int id);
        Task Delete(int EmployeeId);
        //We're passing the Employee Id to check if the employee
        //is union member, then a union fee will apply to this employee.
        decimal UnionFees(int id);
        //We're passing the Employee Id to check if the employee
        //is paying student loan, Also we need to know the total amount this employee has earned.
        decimal StudenLoanRepaymentAmount(int id, decimal TotalAmount);
        IEnumerable<Employee> GetAllEmployees();
        
    }
}
