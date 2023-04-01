﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Services.WebApi.Helpers;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography;

namespace Pacagroup.Ecommerce.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _userApplication;
        private readonly AppSettings _appSettings;
        public UsersController(IUsersApplication userApplication, IOptions<AppSettings>appSettings)
        {
            _userApplication = userApplication;
            _appSettings = appSettings.Value;
        }
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UsersDTO userDTO)
        {           
            var response = _userApplication.Authenticate(userDTO.UserName, userDTO.Password);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                {
                    return NotFound(response.Message);
                }                    
            }
            return BadRequest(response.Message);              
        }
        private string BuildToken(Response<UsersDTO> usersDTO)
        {
            _appSettings.Secret = GenerateRandomString(64);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usersDTO.Data.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
        static string GenerateRandomString(int length)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[length];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
