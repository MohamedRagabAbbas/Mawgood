using Mawgood.Core.Models;
using Mawgood.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MawgoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public JobSeekerController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.JobSeekers.GetAllAsync();
            return Ok(response);
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _unitOfWork.JobSeekers.GetByIdAsync(id);
            return Ok(response);
        }
        [Route("get-by-user-id/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _unitOfWork.JobSeekers.GetFirstAsync(x => x.UserId == userId);
            return Ok(response);
        }
        // update job seeker
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] JobSeeker jobSeeker)
        {
            _unitOfWork.JobSeekers.Update(jobSeeker);
            return Ok();
        }
        // delete job seeker
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.JobSeekers.Delete(id);
            return Ok();
        }
    }
}
