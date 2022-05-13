
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;

namespace Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersApplication _customersApplication;

        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        #region Metodos Sincronos

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = _customersApplication.Insert(customersDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = _customersApplication.Update(customersDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{customerid}")]
        public IActionResult Delete(string customerid)
        {
            if (string.IsNullOrEmpty(customerid))
                return BadRequest();

            var response = _customersApplication.Delete(customerid);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{customerid}")]
        public IActionResult Get(string customerid)
        {
            if (string.IsNullOrEmpty(customerid))
                return BadRequest();

            var response = _customersApplication.Get(customerid);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _customersApplication.GetAll();

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion


        #region Metodos Asincronos

        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = await _customersApplication.InsertAsync(customersDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = await _customersApplication.UpdateAsync(customersDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("DeleteAsync/{customerid}")]
        public async Task<IActionResult> DeleteAsync(string customerid)
        {
            if (string.IsNullOrEmpty(customerid))
                return BadRequest();

            var response = await _customersApplication.DeleteAsync(customerid);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAsync/{CustomerId}")]
        public async Task<IActionResult> GetAsync(string CustomerId)
        {
            if (string.IsNullOrEmpty(CustomerId))
                return BadRequest();

            var response = await _customersApplication.GetAsync(CustomerId);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersApplication.GetAllAsync();

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion
    }
}
