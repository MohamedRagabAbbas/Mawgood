using AutoMapper;
using Mawgood.Core.AutoMapper;
using Mawgood.Core.DTO.Request;
using Mawgood.Core.IRepositories;
using Mawgood.Core.Models;
using Mawgood.EF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MawgoodApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapper;
        public ApplicationController(IUnitOfWork unitOfWork, IMapping mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.Applications.GetAllAsync();
            return Ok(response);
        }
        [Authorize(Roles = "JobSeeker,Employer")]
        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            if(userRole !=null && userRole == "JobSeeker")
            {
                var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
                var jobSeeker = await _unitOfWork.JobSeekers.GetFirstAsync(x => x.UserId == userId);
                if (jobSeeker == null || jobSeeker.Data == null)
                {
                    return NotFound();
                }
                var jobSeekerIdFromToken = jobSeeker.Data.Id;

                var application = await _unitOfWork.Applications.GetByIdAsync(id);
                if (application == null || application.Data == null)
                {
                    return NotFound();
                }
                var _jobSeekerId = application.Data.JobSeekerId;
                if (_jobSeekerId != jobSeekerIdFromToken)
                {
                    return Unauthorized();
                }
            }
            // I need to make another condition for the employer, but I will do it latter 
            var response = await _unitOfWork.Applications.GetByIdAsync(id);
            return Ok(response);
        }
        [Authorize(Roles = "Employer")]
        [Route("get-all-for-job/{jobId}/{emplyerId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllForJob(int jobId)
        {
            // get the employerId from the token
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var employer = await _unitOfWork.Employers.GetFirstAsync(x => x.UserId == userId);
            if (employer == null || employer.Data == null)
            {
                return NotFound();
            }
            var employerIdFromToken = employer.Data.Id;
            var job = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (job == null || job.Data == null)
            {
                return NotFound();
            }
            var _employerId = job.Data.EmployerId;
            if (_employerId != employerIdFromToken)
            {
                return Unauthorized();
            }
            var response = await _unitOfWork.Applications.GetWhereAsync(x => x.JobId == jobId);
            return Ok(response);
        }
        [Authorize(Roles = "JobSeeker")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationInfo applicationInfo)
        {
            var application = _mapper.ApplicationInfoToApplication(applicationInfo);
            var response = await _unitOfWork.Applications.Add(application);
            _unitOfWork.Complete();
            return Ok(response);
        }
        [Authorize(Roles = "JobSeeker")]
        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] ApplicationInfo applicationInfo,int applicationId)
        {
            // Authentcation, Make sure the jobSeekerId in the token is the same as the jobSeekerId in the application, and he is the owner of the application
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var jobSeeker = await _unitOfWork.JobSeekers.GetFirstAsync(x => x.UserId == userId);
            if (jobSeeker == null || jobSeeker.Data == null)
            {
                return NotFound();
            }
            var jobSeekerId = jobSeeker.Data.Id;
            // check if the application exists
            var application = await _unitOfWork.Applications.GetByIdAsync(applicationId);
            if (application == null || application.Data == null)
            {
                return NotFound();
            }
            var _jobSeekerId = application.Data.JobSeekerId;
            // chechs if the jobSeekerId in the token is the same as the jobSeekerId in the application
            if (_jobSeekerId != jobSeekerId)
            {
                return Unauthorized();
            }

            var updatedApplication = _mapper.ApplicationInfoToApplication(applicationInfo, applicationId);
            _unitOfWork.Applications.Update(updatedApplication);
            var result = _unitOfWork.Complete();
            return Ok(result != 0 ? "Updated Successfully..." : "Something went wrong...");
        }
        [Authorize(Roles = "JobSeeker")]
        [Route("delete")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // get the jobSeekerId from the token
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var jobSeeker = await _unitOfWork.JobSeekers.GetFirstAsync(x => x.UserId == userId);
            if (jobSeeker == null || jobSeeker.Data == null)
            {
                return NotFound();
            }
            var jobSeekerId = jobSeeker.Data.Id;

            // check if the application exists
            var application = await _unitOfWork.Applications.GetByIdAsync(id);
            if (application == null || application.Data == null)
            {
                return NotFound();
            }
            var _jobSeekerId = application.Data.JobSeekerId;
            // chechs if the jobSeekerId in the token is the same as the jobSeekerId in the application
            if (_jobSeekerId != jobSeekerId)
            {
                return Unauthorized();
            }
            await _unitOfWork.Applications.Delete(id);
            var result = _unitOfWork.Complete();
            return Ok(result != 0 ? "Deleted Successfully..." : "Something went wrong...");
        }

    }
}
