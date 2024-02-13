using AutoMapper;
using Mawgood.Core.DTO.Request;
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
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public JobController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
           var job = _mapper.Map<Job>(jobInfo);
            var response = await _unitOfWork.Jobs.Add(job);
            _unitOfWork.Complete();
            return Ok(response);
        }

    }
}
