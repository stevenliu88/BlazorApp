using EmployeeManagement.Models;
using EmployeeManagements.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagements.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository _employeeRepository)
        {
            this.employeeRepository = _employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees() {
            try
            {
                return Ok(await employeeRepository.GetEmployees());
            }
            catch (Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if (result == null)
                {
                    return NotFound();
                }
                else {                 
                    return Ok(result);
                }
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Unable to get Employee detail");
            }
        }


    }
}
