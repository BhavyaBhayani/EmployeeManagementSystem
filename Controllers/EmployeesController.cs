using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeMasterContext _dbContext;

        public EmployeesController(EmployeeMasterContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public List<vmEmployeeData> GetEmployees()
        {
            var data = (from r in _dbContext.EmployeeMasters
                        join D in _dbContext.DepartmentMasters on r.DepartmentId equals D.DepartmentId
                        where r.IsActive == true && r.IsDeleted == false
                        select new vmEmployeeData
                        {
                            DepartmentId = r.DepartmentId,
                            EmailId = r.EmailId,
                            EmployeeId = r.EmployeeId, 
                            EmployeeName = r.EmployeeName,
                            DepartmentName=D.DepartmentName,
                            DateOfBirth =r.DateOfBirth
                        }
                        ).ToList();


            return data;
        }

        [HttpGet("{id}")]
        public vmEmployeeData GetEmployee(int id)
        {
            var employee = (from r in _dbContext.EmployeeMasters
                            join D in _dbContext.DepartmentMasters on r.DepartmentId equals D.DepartmentId
                            where r.EmployeeId == id && r.IsActive == true && r.IsDeleted == false
                            select new vmEmployeeData
                            {
                                DepartmentId = r.DepartmentId,
                                EmailId = r.EmailId,
                                EmployeeId = r.EmployeeId,
                                EmployeeName = r.EmployeeName,
                                DepartmentName = D.DepartmentName,
                                DateOfBirth = r.DateOfBirth
                            }
                        ).FirstOrDefault();

            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeMaster>> CreateEmployee(EmployeeMaster employee)
        {
            _dbContext.EmployeeMasters.Add(employee);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] vmEmployeeData employee)
        {
            
            EmployeeMaster employeeData = await _dbContext.EmployeeMasters.FindAsync(employee.EmployeeId);
            if (employeeData == null)
            {
                return BadRequest();
            }
            else
            {
                employeeData.EmployeeName = employee.EmployeeName;
                employeeData.DateOfBirth = employee.DateOfBirth;
                employeeData.EmailId = employee.EmailId;
                employeeData.DepartmentId = employee.DepartmentId;
                employeeData.UpdatedDate = DateTime.Now;
                _dbContext.Entry(employeeData).State = EntityState.Modified;
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.EmployeeMasters.Any(e => e.EmployeeId == employee.EmployeeId))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _dbContext.EmployeeMasters.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }
            employee.IsActive = false;
            employee.IsDeleted= true; 
            employee.UpdatedDate = DateTime.Now;
            _dbContext.Entry(employee).State = EntityState.Modified;
            // _dbContext.EmployeeMasters.Remove(employee); ///TO remove DataEntry forcefully from DB.
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpGet("GetDepartments")]
        public async Task<ActionResult<List<DepartmentMaster>>> GetDepartmentData()
        {
            var departmentData = await _dbContext.DepartmentMasters.Where(r=>r.IsActive==true && r.IsDeleted==false).ToListAsync();

            if (departmentData == null)
                return NotFound();
            else
                return departmentData;
        }

    }

}