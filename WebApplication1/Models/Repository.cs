namespace WebApplication1.Models
{
    public class Repository : IRepository
    {
        Dictionary<int, Employee> employees = new()
{
    { 1, new Employee { Id = 1, Name = "Emp@1", Designation = "Software Engineer" } },
    { 2, new Employee { Id = 2, Name = "Emp@2", Designation = "Software Engineer" } },
    { 3, new Employee { Id = 3, Name = "Emp@3", Designation = "Software Engineer" } },
    { 4, new Employee { Id = 4, Name = "Emp@4", Designation = "Software Engineer" } },
    { 5, new Employee { Id = 5, Name = "Emp@5", Designation = "Software Engineer" } }
};


        public Employee GetEmployee(int id)
        {
            return employees[id];
        }
    }
}
