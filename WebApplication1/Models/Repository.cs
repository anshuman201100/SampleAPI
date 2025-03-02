//namespace WebApplication1.Models
//{
//    public class Repository : IRepository
//    {
//        Dictionary<int, Employee> employees = new()
//{
//    { 1, new Employee { Id = 1, Name = "Emp@1", Designation = "Software Engineer" } },
//    { 2, new Employee { Id = 2, Name = "Emp@2", Designation = "Software Engineer" } },
//    { 3, new Employee { Id = 3, Name = "Emp@3", Designation = "Software Engineer" } },
//    { 4, new Employee { Id = 4, Name = "Emp@4", Designation = "Software Engineer" } },
//    { 5, new Employee { Id = 5, Name = "Emp@5", Designation = "Software Engineer" } }
//};


//        public Employee GetEmployee(int id)
//        {
//            return employees[id];
//        }


//    }
//}

using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public class Repository : IRepository
    {
        private readonly List<Employee> _employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Emp@1", Designation = "Software Engineer" },
                new Employee { Id = 2, Name = "Emp@2", Designation = "Software Engineer" },
                new Employee { Id = 3, Name = "Emp@3", Designation = "Software Engineer" },
                new Employee { Id = 4, Name = "Emp@4", Designation = "Software Engineer" },
                new Employee { Id = 5, Name = "Emp@5", Designation = "Software Engineer" }
            };

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public void AddEmployee(Employee employee)
        {
            employee.Id = _employees.Count > 0 ? _employees.Max(e => e.Id) + 1 : 1;
            _employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Designation = employee.Designation;
                // Update other properties as needed
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = GetEmployee(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}

