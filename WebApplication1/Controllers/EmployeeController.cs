using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Text.Json;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository _repository;

        public EmployeeController(IRepository repository)
        {
            _repository = repository;
        }

            public JsonResult GetEmployee(int id)
            {
            Employee employee = _repository.GetEmployee(id);
            return new JsonResult(employee);
            }
        }
    }
