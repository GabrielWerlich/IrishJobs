using IrishJobs.Data;
using IrishJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrishJobs.Controllers
{
    [ApiController]
    public class CandidateController : ControllerBase
    {   

        private readonly IRepositoryCandidate _repo;

        public CandidateController(IRepositoryCandidate repo)
        {
            _repo = repo;
        }

        [HttpGet("v1/candidate/{id:int}")]
        public async Task<IActionResult> GetAsyncCandidate([FromRoute] int id)
        {
            try
            {
                var result = await _repo.GetCandidate(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }  

        [HttpGet("v1/candidates")]
        public async Task<IActionResult> GetAsyncAllCandidates([FromRoute] int id)
        {
            try
            {
                var result = await _repo.GetAllCandidates();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }          

        [HttpPost("v1/candidate")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CandidateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Json is invalid");

            try
            {
                await _repo.Create(model);
                return Created($"v1/candidate/{model.Id}", $"record {model.Id} created.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }        

        [HttpPut("v1/candidate/{id:int}")]
        public async Task<IActionResult> UpdateAsyncCandidate(
        [FromRoute] int id,
        [FromBody] CandidateModel model)
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

        [HttpDelete("v1/candidate/{id:int}")]
        public async Task<IActionResult> DeleteCandidate(
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