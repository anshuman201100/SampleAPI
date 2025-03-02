namespace WebApplication1.Models
{
    public interface IRepository
    {
        public Employee GetEmployee(int id);
        public IEnumerable<Employee> GetAllEmployees();
        public void AddEmployee(Employee employee);

        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(int id);

    }
}
