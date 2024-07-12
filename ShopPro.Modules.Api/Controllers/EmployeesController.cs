using Microsoft.AspNetCore.Mvc;
using ShopPro.Modules.Application.Dtos.Employees;
using ShopPro.Modules.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopPro.Modules.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            this.employeesService = employeesService;
        }

        [HttpGet("GetEmployees")]
        public IActionResult Get()
        {
            var result = this.employeesService.GetEmployees();

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpGet("GetEmployeesById")]
        public IActionResult Get(int id)
        {
            var result = this.employeesService.GetEmployees(id);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPost("SaveEmployees")]
        public IActionResult Post([FromBody] EmployeesSaveDto saveDto)
        {
            var result = this.employeesService.SaveEmployees(saveDto);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpPut("UpdateEmployees")]
        public IActionResult Put(EmployeesUpdateDto updateDto)
        {
            var result = this.employeesService.UpdateEmployees(updateDto);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }

        [HttpDelete("RemoveEmployees")]
        public IActionResult Delete(EmployeesRemoveDto removeDto)
        {
            var result = this.employeesService.RemoveEmployees(removeDto);

            if (!result.Success)
                return BadRequest(result);
            else
                return Ok(result);
        }
    }
}
