using IrishJobs.Data;
using IrishJobs.Data.Repositories;
using IrishJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrishJobs.Controllers
{
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IRepositoryAd _repo;

        public AdsController(IRepositoryAd repo)
        {
            _repo = repo;
        }

        [HttpGet("v1/ads")]
        public async Task<IActionResult> GetAllAdsAsync()
        {
            try
            {
                var result =  await _repo.GetAsyncAds();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }   

        [HttpGet("v1/ads/company/{id}")]
        public async Task<IActionResult> GetAsyncByCompany([FromRoute] int id)
        {
            try
            {
                var result = await _repo.GetAsyncAdsByCompany(id);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }  
        
        [HttpPost("v1/ads")]
        public async Task<IActionResult> PostAsync(
            [FromBody] AdModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Json is invalid");

            try
            {
                await _repo.Create(model);
                return Created($"v1/ads/{model.Id}", $"record {model.Id} created.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPut("v1/ads/{id:int}")]
        public async Task<IActionResult> UpdateAsyncAd(
        [FromBody] AdModel model)
        {
            if (!ModelState.IsValid)
            return BadRequest("Json is invalid");

            try
            {
                await _repo.Update(model);
                return Ok($"record {model.Id} updated.");
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpDelete("v1/ads/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            return BadRequest("Json is invalid");

            try
            {
                await _repo.Delete(id);
                return Ok($"record {id} deleted.");
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost("v1/teste")]
        public async Task<IActionResult> PostAsync(
            [FromBody] AdCandidateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Json is invalid");

            try
            {
                await _repo.CandidateSubscribe(model.AdId,model.CandidateId);
                return Ok($"record created.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
    
}