using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingApp.Application.Common.Interfaces;
using ShoppingApp.Application.Common.Model.Identity;
using ShoppingApp.Domain.Consts;
using ShoppingApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IdentityService(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddRoleAsync(UserRoleModel userRole)
        {
            bool result = false;
            User userExist = await _unitOfWork.UserReadRepository.FindAsync(x => x.Id == userRole.UserId, true);
            Role roleExist = await _unitOfWork.RoleReadRepository.FindAsync(x => x.Id == userRole.RoleId);

            if (userExist != null && roleExist != null)
            {
                roleExist.Users.Add(userExist);
                bool updatedRole = await _unitOfWork.RoleWriteRepository.UpdateAsync(roleExist);
                bool updatedUser = await _unitOfWork.UserWriteRepository.UpdateAsync(userExist);
                _unitOfWork.SaveChanges();
                if (updatedRole)
                {
                    result = true;
                }
            }
            return result;
        }

        public async Task<bool> AddRolesAsync(UserRolesModel userRoles)
        {
            bool result = false;
            User userExist = await _unitOfWork.UserReadRepository.FindAsync(x => x.Id == userRoles.UserId, true, x => x.Roles);
            if (userExist != null && userRoles.Roles.Any())
            {
                foreach (int roleId in userRoles.Roles)
                {
                    Role roleExist = await _unitOfWork.RoleReadRepository.FindAsync(x => x.Id == roleId);
                    if (roleExist != null)
                    {
                        userExist.Roles.Add(roleExist);
                    }
                }
                bool updatedUser = await _unitOfWork.UserWriteRepository.UpdateAsync(userExist);
                _unitOfWork.SaveChanges();
                if (updatedUser)
                {
                    result = true;
                }
            }
            return result;
        }

        public async Task<string> LoginAsync(LoginModel user)
        {
            User userExist = await _unitOfWork.UserReadRepository.FindAsync(x => x.Email == user.Email && x.Password == user.Password, true, a => a.Roles);
            if (userExist != null)
            {
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                List<Claim> authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.Email),
                    new Claim(ClaimTypes.NameIdentifier,userExist.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };

                User loginedUser = await _unitOfWork.UserReadRepository.FindAsync(w => w.Id == userExist.Id, includeProperties: w => w.Roles);
                if (loginedUser != null)
                {
                    foreach (Role userRole in loginedUser.Roles)
                    {
                        if (userRole != null)
                        {
                            authClaims.Add(new Claim(ClaimTypes.Role, userRole.Name));
                        }
                    }
                }
                string token = GetToken(authClaims);

                return token;
            }
            return null;
        }

        public async Task<bool> RegisterAsync(RegisterModel user)
        {
            User userExist = await _unitOfWork.UserReadRepository.FindAsync(x => x.Email == user.Email && x.Password == user.Password);
            bool result = false;
            if (userExist == null)
            {
                User newUser = _mapper.Map<User>(user);
                await _unitOfWork.UserWriteRepository.AddAsync(newUser);
                Role defaultRole = await _unitOfWork.RoleReadRepository.FindAsync(f => f.Name.Equals(UserRoles.Member));
                if (defaultRole != null)
                {
                    defaultRole.Users.Add(newUser);
                    bool addUserResult = await _unitOfWork.RoleWriteRepository.UpdateAsync(defaultRole);
                    _unitOfWork.SaveChanges();
                    if (addUserResult) result = true;
                }
            }
            return result;
        }
        private string GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
