using IrishJobs.Data;
using IrishJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrishJobs.Controllers
{
    [ApiController]
    public class CompanyController : ControllerBase
    {   

        private readonly IRepositoryCompany _repo;

        public CompanyController(IRepositoryCompany repo)
        {
            _repo = repo;
        }

        [HttpGet("v1/company/{id:int}")]
        public async Task<IActionResult> GetAsyncCompany([FromRoute] int id)
        {
            try
            {
                var result = await _repo.GetCompany(id);
                return Ok(result);
            }
            catch(Exception ex) 
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }  

        [HttpGet("v1/companies")]
        public async Task<IActionResult> GetAsyncAllCompanies([FromRoute] int id)
        {
            try
            {
                var result = await _repo.GetAllCompanies();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }          

        [HttpPost("v1/company")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CompanyModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Json is invalid");

            try
            {
                await _repo.Create(model);
                return Created($"v1/company/{model.Id}", $"record {model.Id} created.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("v1/company/{id:int}")]
        public async Task<IActionResult> UpdateAsyncCompany(
        [FromRoute] int id,
        [FromBody] CompanyModel model)
        {
            if (!ModelState.IsValid)
            return BadRequest("Json is invalid");

            try
            {
                var updated = await _repo.Update(model);
                if(updated == 1)
                    return Ok($"record {model.Id} updated.");

                return BadRequest($"record {model.Id} was not updated.");
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("v1/company/{id:int}")]
        public async Task<IActionResult> DeleteAsyncCompany(
        [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            return BadRequest("Json is invalid");

            try
            {
                await _repo.Delete(id);
                return Ok($"record {id} was deleted.");
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }        

    }
}