using AutoMapper;
using Mawgood.Core.DTO.Request;
using Mawgood.Core.Models;
using Mawgood.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MawgoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ApplicationController(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.Applications.GetAllAsync();
            return Ok(response);
        }
        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _unitOfWork.Applications.GetByIdAsync(id);
            return Ok(response);
        }
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ApplicationInfo applicationInfo)
        {
            var application = _mapper.Map<Application>(applicationInfo);
            var response = await _unitOfWork.Applications.Add(application);
            _unitOfWork.Complete();
            return Ok(response);
        }
    }
}
