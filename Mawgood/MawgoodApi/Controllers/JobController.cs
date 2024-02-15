using AutoMapper;
using Mawgood.Core.AutoMapper;
using Mawgood.Core.DTO.Request;
using Mawgood.Core.IRepositories;
using Mawgood.Core.Models;
using Mawgood.EF.AutoMapping;
using Mawgood.EF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MawgoodApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;
        public JobController(IUnitOfWork unitOfWork, IMapping mapping)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
        }
        [Authorize(Roles = "Admin")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.Jobs.GetAllAsync();
            return Ok(response);
        }
        [Authorize(Roles ="Admin,Employer,JobSeeker")]
        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _unitOfWork.Jobs.GetByIdAsync(id);
            return Ok(response);
        }
        [Authorize(Roles = "Employer")]
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobInfo jobInfo)
        {
           var job = _mapping.JobInfoToJob(jobInfo);
            var response = await _unitOfWork.Jobs.Add(job);
            _unitOfWork.Complete();
            return Ok(response);
        }
        [Authorize(Roles = "Employer")]
        [Route("create-range")]
        [HttpPost]
        public async Task<IActionResult> CreateRange([FromBody] List<JobInfo> jobInfos)
        {
            var jobs = _mapping.JobInfoLisToJobList(jobInfos);
            await _unitOfWork.Jobs.AppRanage(jobs.ToList());
            var result = _unitOfWork.Complete();
            return Ok(result!=0?"Added Successfully...":"Something went wrong...");
        }
        [Authorize(Roles = "Employer")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] JobInfo jobInfo, int jobId)
        {
            // authentcation, Make sure the employer is the owner of the job
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var employer = await _unitOfWork.Employers.GetFirstAsync(x => x.UserId == userId);
            if (employer == null || employer.Data == null)
            {
                return NotFound();
            }
            var employerIdFromToken = employer.Data.Id;
            if (employerIdFromToken != jobInfo.EmployerId)
            {
                return Unauthorized();
            }
            var job = _mapping.JobInfoToJob(jobInfo, jobId);
            _unitOfWork.Jobs.Update(job);
            var result = _unitOfWork.Complete();
            return Ok(result != 0 ? "Added Successfully..." : "Something went wrong...");
        }
        [Authorize(Roles = "Employer")]
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            // authentication, Making sure that the employer is the owner of the job
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var employer = await _unitOfWork.Employers.GetFirstAsync(x => x.UserId == userId);
            if (employer == null || employer.Data == null)
            {
                return NotFound();
            }
            var employerIdFromToken = employer.Data.Id;
            var job = await _unitOfWork.Jobs.GetByIdAsync(id);
            if(job == null || job.Data  == null || employerIdFromToken != job.Data.EmployerId)
            {
                return Unauthorized();
            }
           
            await _unitOfWork.Jobs.Delete(id);
            var result = _unitOfWork.Complete();
            return Ok(result != 0 ? "Added Successfully..." : "Something went wrong...");
        }

    }
}
