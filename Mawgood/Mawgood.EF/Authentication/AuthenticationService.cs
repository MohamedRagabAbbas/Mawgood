using Mawgood.Core.DTO.Request;
using Mawgood.Core.DTO.Response;
using Mawgood.Core.IRepositories;
using Mawgood.Core.Jwt;
using Mawgood.Core.Models;
using Mawgood.EF.DB;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.EF.Authentication
{
    public  class AuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly Jwt _jwt;
        private readonly Token _token;
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationService(UserManager<User> userManager, Jwt jwt, Token token, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _jwt = jwt;
            _token = token;
            _unitOfWork = unitOfWork;
        }
        public async Task<AuthenticationResponse> Authenticate(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                if (role != null)
                {
                      if (role == "Employer")
                        {
                            var employer = _unitOfWork.Employers.GetFirstAsync(x => x.UserId == user.Id);
                            return new AuthenticationResponse()
                            {
                                Id = employer.Id,
                                Role = role,
                                IsAuthenticated = true,
                                Token = _token.GenerateToken(user.Id)
                            };
                        }
                    else if (role == "JobSeeker")
                    {
                        var jobSeeker = _unitOfWork.JobSeekers.GetFirstAsync(x => x.UserId == user.Id);
                        return new AuthenticationResponse()
                        {
                            Id = jobSeeker.Id,
                            Role = role,
                            IsAuthenticated = true,
                            Token = _token.GenerateToken(user.Id)
                        };
                    }
                }
                return new AuthenticationResponse();
            }
            return new AuthenticationResponse();
        }
        // job seeker register
        public async Task<AuthenticationResponse> RegisterJobSeeker(JobSeekerRegistrationRequest model)
        {
            var user = new User()
            { 
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //add Role
                await _userManager.AddToRoleAsync(user, "JobSeeker");
                var jobSeeker = new JobSeeker
                {
                    UserId = user.Id,
                    Feild = model.Feild,
                    ImageUrl = model.ImageUrl,
                    CvUrl = model.CvUrl
                };
                var JS = await _unitOfWork.JobSeekers.Add(jobSeeker) ;
                _unitOfWork.Complete();
                return new AuthenticationResponse()
                {
                    Id = JS.Data.Id,
                    Role = "JobSeeker",
                    IsAuthenticated = true,
                    Token = _token.GenerateToken(user.Id)
                };
            }
            return new AuthenticationResponse();
        }
        // employer register
        public async Task<AuthenticationResponse> RegisterEmployer(EmployerRegistrationRequest model)
        {
            var user = new User()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.CompanyPhone,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //add Role
                await _userManager.AddToRoleAsync(user, "Employer");
                var employer = new Employer
                {
                    UserId = user.Id,
                    CompanyName = model.CompanyName,
                    CompanyLogoUrl = model.CompanyLogoUrl,
                    CompanyPhone = model.CompanyPhone,
                    CompanyWebsite = model.CompanyWebsite,
                    CompanyDescription = model.CompanyDescription,
                    CompanyLocation = model.CompanyLocation,
                    CompanyEmail = model.CompanyEmail,
                    CompanyMobile = model.CompanyMobile,
                    CompanySocialMedia = model.CompanySocialMedia,
                    CompanyIndustry = model.CompanyIndustry,
                    CompanySize = model.CompanySize,
                    CompanyType = model.CompanyType,
                    CompanyFounded = model.CompanyFounded,
                    CompanySpecialties = model.CompanySpecialties,
                    CompanyMission = model.CompanyMission,
                    CompanyVision = model.CompanyVision,
                    CompanyServices = model.CompanyServices
                };
                var E = await _unitOfWork.Employers.Add(employer);
                _unitOfWork.Complete();
                return new AuthenticationResponse()
                {
                    Id = E.Data.Id,
                    Role = "Employer",
                    IsAuthenticated = true,
                    Token = _token.GenerateToken(user.Id)
                };
            }
            return new AuthenticationResponse();
        }
    }
}
