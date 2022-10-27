using Business.Repositories.RequestFileRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestFilesController : ControllerBase
    {
        private readonly IRequestFileService _requestFileService;

        public RequestFilesController(IRequestFileService requestFileService)
        {
            _requestFileService = requestFileService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(RequestFile requestFile)
        {
            var result = await _requestFileService.Add(requestFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(RequestFile requestFile)
        {
            var result = await _requestFileService.Update(requestFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(RequestFile requestFile)
        {
            var result = await _requestFileService.Delete(requestFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _requestFileService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _requestFileService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
