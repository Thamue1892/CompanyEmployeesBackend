using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
       private readonly IServiceManager _service;

       public EmployeesController(IServiceManager service) => _service = service;

       [HttpGet]
       public IActionResult GetEmployeesForCompany(Guid companyId)
       {
            var company = _service.CompanyService.GetCompany(companyId, trackChanges:false);
            if (company == null)
            {
                return NotFound();
            }
            var employeesFromDb = _service.EmployeeService.GetEmployees(companyId, trackChanges:false);
            return Ok(employeesFromDb);
        }
    }
}
