using AutoMapper;
using Mawgood.Core.AutoMapper;
using Mawgood.Core.DTO.Request;
using Mawgood.Core.IRepositories;
using Mawgood.Core.Models;
using Mawgood.EF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize(Roles = "JobSeeker")]
        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id,int jobSeekerId)
        {
            var application = await _unitOfWork.Applications.GetByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            var _jobSeekerId = application.Data.JobSeekerId;
            if (_jobSeekerId != jobSeekerId)
            {
                return Unauthorized();
            }
            var response = await _unitOfWork.Applications.GetByIdAsync(id);
            return Ok(response);
        }
        [Authorize(Roles = "Employer")]
        [Route("get-all-for-job/{jobId}/{emplyerId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllForJob(int jobId,int emplyerId)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (job == null)
            {
                return NotFound();
            }
            var _employerId = job.Data.EmployerId;
            if (_employerId != emplyerId)
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
        public async Task<IActionResult> Update([FromBody] ApplicationInfo applicationInfo,int applicationId, int jobSeekerId)
        {
            var application = await _unitOfWork.Applications.GetByIdAsync(applicationId);
            if (application == null)
            {
                return NotFound();
            }
            var _jobSeekerId = application.Data.JobSeekerId;
            if (_jobSeekerId != jobSeekerId)
            {
                return Unauthorized();
            }
            var updatedApplication = _mapper.ApplicationInfoToApplication(applicationInfo);
            _unitOfWork.Applications.Update(updatedApplication);
            var result = _unitOfWork.Complete();
            return Ok(result != 0 ? "Updated Successfully..." : "Something went wrong...");
        }
        [Authorize(Roles = "JobSeeker")]
        [Route("delete")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id,int jobSeekerId)
        {
            var application = await _unitOfWork.Applications.GetByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            var _jobSeekerId = application.Data.JobSeekerId;
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
