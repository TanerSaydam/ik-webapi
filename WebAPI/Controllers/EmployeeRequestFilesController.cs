using Business.Repositories.EmployeeRequestFileRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRequestFilesController : ControllerBase
    {
        private readonly IEmployeeRequestFileService _employeeRequestFileService;

        public EmployeeRequestFilesController(IEmployeeRequestFileService employeeRequestFileService)
        {
            _employeeRequestFileService = employeeRequestFileService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(EmployeeRequestFile employeeRequestFile)
        {
            var result = await _employeeRequestFileService.Add(employeeRequestFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(EmployeeRequestFile employeeRequestFile)
        {
            var result = await _employeeRequestFileService.Update(employeeRequestFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(EmployeeRequestFile employeeRequestFile)
        {
            var result = await _employeeRequestFileService.Delete(employeeRequestFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _employeeRequestFileService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{employeeId}/{fileId}")]
        public async Task<IActionResult> GetById(int employeeId, int fileId)
        {
            var result = await _employeeRequestFileService.GetById(employeeId, fileId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);            
        }

    }
}
