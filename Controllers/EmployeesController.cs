using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDP_WebAPI_Security.Context;
using EDP_WebAPI_Security.Models;
using Microsoft.AspNetCore.Authorization;
using EDP_WebAPI_Security.Dtos;
using AutoMapper;

namespace EDP_WebAPI_Security.Controllers
{
    [Route("api/employee")]
    [ApiController]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly RhContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(RhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = ("Employee, Manager, Administrator"))]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }

            List<Employee> employee = await _context.Employee.ToListAsync();

            var user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;


            return employee;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = ("Employee, Manager, Administrator"))]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPut("update-salary/{id}")]
        [Authorize(Roles = ("Manager"))]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("create-employee")]
        //[Authorize(Roles = ("Administrator"))]
        public async Task<ActionResult<Employee>> PostEmployee(FuncionarioRequest request)
        {
            if (_context.Employee == null)
            {
                return Problem("Entity set 'RhContext.Employee'  is null.");
            }

            //_context.Employee.Add(_mapper.Map<Employee>(request)); 
            //await _context.SaveChangesAsync();

            return StatusCode(201);
        }

        [HttpDelete("delete-employee/{id}")]
        [Authorize(Roles = ("Manager, Administrator"))]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("delete-manager/{id}")]
        [Authorize(Roles = ("Administrator"))]
        public async Task<IActionResult> DeleteManager(int id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
