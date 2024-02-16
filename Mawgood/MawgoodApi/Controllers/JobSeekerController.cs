using Mawgood.Core.IRepositories;
using Mawgood.Core.Models;
using Mawgood.EF.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MawgoodApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        [Authorize(Roles = "Admin")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.JobSeekers.GetAllAsync();
            return Ok(response);
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "JobSeeker")]
        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId==null)
            {
                return Unauthorized();
            }
            var jobSeeker = await _unitOfWork.JobSeekers.GetFirstAsync(x => x.UserId == userId);
            if (jobSeeker == null || jobSeeker.Data == null)
            {
                return NotFound();
            }
            var id = jobSeeker.Data.Id;
            var response = await _unitOfWork.JobSeekers.GetByIdAsync(id);
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _unitOfWork.JobSeekers.GetByIdAsync(id);
            return Ok(response);
        }
        [Authorize (Roles = "Admin")]
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var jobSeekerFromDb = await _unitOfWork.JobSeekers.GetFirstAsync(x => x.UserId == userId);
            if (jobSeekerFromDb == null || jobSeekerFromDb.Data == null)
            {
                return NotFound();
            }
            if(jobSeeker.Id != jobSeekerFromDb.Data.Id)
            {
                return Unauthorized();
            }
            _unitOfWork.JobSeekers.Update(jobSeeker);
            _unitOfWork.Complete();
            return Ok();
        }
        // delete job seeker
        [Authorize (Roles = "Admin")]
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.JobSeekers.Delete(id);
            _unitOfWork.Complete();
            return Ok();
        }
        [Authorize(Roles = "JobSeeker")]
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var jobSeeker = await _unitOfWork.JobSeekers.GetFirstAsync(x => x.UserId == userId);
            if (jobSeeker == null || jobSeeker.Data == null)
            {
                return NotFound();
            }
            var id = jobSeeker.Data.Id;
            await _unitOfWork.JobSeekers.Delete(id);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
