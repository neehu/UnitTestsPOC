using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _context { get; set; }
        public EmployeeRepository()
        {
            _context = new EmployeeContext();
        }
        public void DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
