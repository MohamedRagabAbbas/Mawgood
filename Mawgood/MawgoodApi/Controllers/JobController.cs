using AutoMapper;
using Mawgood.Core.AutoMapper;
using Mawgood.Core.DTO.Request;
using Mawgood.Core.IRepositories;
using Mawgood.Core.Models;
using Mawgood.EF.AutoMapping;
using Mawgood.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MawgoodApi.Controllers
{
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
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.Jobs.GetAllAsync();
            return Ok(response);
        }
        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _unitOfWork.Jobs.GetByIdAsync(id);
            return Ok(response);
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JobInfo jobInfo)
        {
           var job = _mapping.FromJobInfoToJob(jobInfo);
            var response = await _unitOfWork.Jobs.Add(job);
            _unitOfWork.Complete();
            return Ok(response);
        }
        [Route("create-range")]
        [HttpPost]
        public async Task<IActionResult> CreateRange([FromBody] List<JobInfo> jobInfos)
        {
            var jobs = _mapping.FromtJobInfoLisToJobList(jobInfos);
            await _unitOfWork.Jobs.AppRanage(jobs.ToList());
            var result = _unitOfWork.Complete();
            return Ok(result!=0?"Added Successfully...":"Something went wrong...");
        }

    }
}
