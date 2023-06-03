﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

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

       [HttpGet("{id:guid}",Name = "GetEmployeeForCompany")]
       public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
       {
            
            var employee = _service.EmployeeService.GetEmployee(companyId, id, trackChanges:false);
            
            return Ok(employee);
        }

       [HttpPost]
       public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
       {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges:false);

            return CreatedAtRoute("GetEmployeeForCompany", new {companyId, id = employeeToReturn.Id}, employeeToReturn);
            
        }

       [HttpDelete("{id:guid}")]
       public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
       {
            _service.EmployeeService.DeleteEmployeeForCompany(companyId, id, trackChanges:false);
            return NoContent();
        }
    }
}
