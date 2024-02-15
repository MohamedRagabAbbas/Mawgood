using Mawgood.Core.IRepositories;
using Mawgood.Core.Models;
using Mawgood.EF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MawgoodApi.Controllers
{
    [Authorize(Roles = "Employer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.Employers.GetAllAsync();
            return Ok(response);
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _unitOfWork.Employers.GetByIdAsync(id);
            return Ok(response);
        }
        [Route("get-by-user-id/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _unitOfWork.Employers.GetFirstAsync(x => x.UserId == userId);
            return Ok(response);
        }
        // update employer
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employer employer)
        {
            _unitOfWork.Employers.Update(employer);
            _unitOfWork.Complete();
            return Ok();
        }
        // delete employer
        [Route("delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.Employers.Delete(id);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
