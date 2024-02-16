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
        [Authorize(Roles ="Admin")]
        [Route("get-all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _unitOfWork.Employers.GetAllAsync();
            return Ok(response);
        }
        [Authorize(Roles = "Admin,Employer")]
        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            if(User.FindFirst(ClaimTypes.Role) !=null)
            {
                var userRole = User.FindFirstValue(ClaimTypes.Role);
                if (userRole != null && userRole == "Employer")
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var employer = await _unitOfWork.Employers.GetFirstAsync(x => x.UserId == userId);
                    if (employer == null || employer.Data == null)
                    {
                        return NotFound();
                    }
                    var employerIdFromToken = employer.Data.Id;
                    var response = await _unitOfWork.Employers.GetByIdAsync(employerIdFromToken);
                    return Ok(response);
                }
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _unitOfWork.Employers.GetByIdAsync(id);
            return NotFound();
        }
        
        [Authorize(Roles = "Admin,Employer")]
        [Route("get-by-user-id/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            if (userRole != null && userRole == "Employer")
            {
                var userIdFromToken = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdFromToken == null || userIdFromToken.Value != userId)
                {
                    return Unauthorized();
                }
            }
            var response = await _unitOfWork.Employers.GetFirstAsync(x => x.UserId == userId);
            return Ok(response);
        }
        // update employer
        [Authorize(Roles = "Admin,Employer")]
        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employer employer)
        {
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            if (userRole != null && userRole == "Employer")
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var employerFromDb = await _unitOfWork.Employers.GetFirstAsync(x => x.UserId == userId);
                if (employerFromDb == null || employerFromDb.Data == null)
                {
                    return NotFound();
                }
                if (employer.Id != employerFromDb.Data.Id)
                {
                    return Unauthorized();
                }
            }
            _unitOfWork.Employers.Update(employer);
            _unitOfWork.Complete();
            return Ok();
        }
        // delete employer
        [Authorize(Roles = "Employer")]
        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employer = await _unitOfWork.Employers.GetFirstAsync(x => x.UserId == userId);
            if (employer == null || employer.Data == null)
            {
                return NotFound();
            }
            var id = employer.Data.Id;
            await _unitOfWork.Employers.Delete(id);
            _unitOfWork.Complete();
            return Ok();
        }

        // delete employer
        [Authorize(Roles = "Admin")]
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
