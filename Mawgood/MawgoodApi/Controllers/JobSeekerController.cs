using Mawgood.Core.IRepositories;
using Mawgood.Core.Models;
using Mawgood.EF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MawgoodApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public JobSeekerController(IUnitOfWork unitOfWork)
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
        [Authorize(Roles = "JobSeeker")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] JobSeeker jobSeeker)
        {
            _unitOfWork.JobSeekers.Update(jobSeeker);
            _unitOfWork.Complete();
            return Ok();
        }
        // delete job seeker
        [Authorize(Roles = "JobSeeker")]
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.JobSeekers.Delete(id);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
