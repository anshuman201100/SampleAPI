using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository _repository;

        public EmployeeController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ResponseModel<object>
                {
                    StatusCode = 400,
                    Error = "user id is required"
                });
            }

            Employee employee = _repository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound(new ResponseModel<object>
                {
                    StatusCode = 404,
                    Error = "user not found"
                });
            }

            return Ok(new ResponseModel<object>
            {
                StatusCode = 200,
                Message = "user fetched successfully",
                Data = new
                {
                    name = employee.Name,
                    email = "", // Assuming email is not part of Employee model, add if available
                    designation = employee.Designation
                }
            });
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest(new ResponseModel<object>
                {
                    StatusCode = 400,
                    Error = "employee data is required"
                });
            }

            _repository.AddEmployee(employee);

            return Ok(new ResponseModel<object>
            {
                StatusCode = 201,
                Message = "employee created successfully",
                Data = employee
            });
        }

        [HttpGet]
        public IActionResult ListEmployees()
        {
            var employees = _repository.GetAllEmployees();

            return Ok(new ResponseModel<IEnumerable<Employee>>
            {
                StatusCode = 200,
                Message = "employees fetched successfully",
                Data = employees // Ensure the data is of type IEnumerable<Employee>
            });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ResponseModel<object>
                {
                    StatusCode = 400,
                    Error = "user id is required"
                });
            }

            var employee = _repository.GetEmployee(id);
            if (employee == null)
            {
                return NotFound(new ResponseModel<object>
                {
                    StatusCode = 404,
                    Error = "user not found"
                });
            }

            _repository.DeleteEmployee(id);

            return Ok(new ResponseModel<object>
            {
                StatusCode = 200,
                Message = "employee deleted successfully"
            });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            if (id <= 0 || employee == null)
            {
                return BadRequest(new ResponseModel<object>
                {
                    StatusCode = 400,
                    Error = "valid user id and employee data are required"
                });
            }

            var existingEmployee = _repository.GetEmployee(id);
            if (existingEmployee == null)
            {
                return NotFound(new ResponseModel<object>
                {
                    StatusCode = 404,
                    Error = "user not found"
                });
            }

            employee.Id = id;
            _repository.UpdateEmployee(employee);

            return Ok(new ResponseModel<object>
            {
                StatusCode = 200,
                Message = "employee updated successfully",
                Data = employee
            });
        }
    }
}
