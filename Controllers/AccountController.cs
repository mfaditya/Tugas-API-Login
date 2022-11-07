using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Context;
using API.Handlers;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountRepository _repositoryController;
        public IConfiguration _configuration;
        public AccountController(IConfiguration config, AccountRepository accountRepository)
        {
            _configuration = config;
            _repositoryController = accountRepository;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            try
            {
                var data = _repositoryController.Login(email, password);
                
                if (data != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", data[0]),
                        new Claim("FullName", data[1]),
                        new Claim("Email", data[2]),
                        new Claim("Role", data[3])
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 400,
                        Message = "Email atau Password Anda Salah!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(string fullName, string email, DateTime birthDate, string password)
        {
            try
            {
                var resultUser = _repositoryController.Register(fullName, email, birthDate, password);
                if (resultUser != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Kamu Berhasil Daftar"
                    });
                }
                return Ok(new
                {
                    StatusCode = 400,
                    Message = "Kamu Gagal Daftar",
                    Data = resultUser
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut]
        [Route("ChangePassword")]
        public ActionResult ChangePassword(string email, string passwordLama, string passwordBaru)
        {
            try
            {
                var result = _repositoryController.ChangePassword(email, passwordLama, passwordBaru);
                if (result != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Kamu Berhasil Daftar"
                    });
                }
                return Ok(new
                {
                    StatusCode = 400,
                    Message = "Kamu Gagal Daftar",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut]
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword(string email, string passwordBaru)
        {
            try
            {
                var result = _repositoryController.ForgotPassword(email, passwordBaru);
                if (result != null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Kamu Berhasil Daftar"
                    });
                }
                return Ok(new
                {
                    StatusCode = 400,
                    Message = "Kamu Gagal Daftar",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
            
        }
    }
}

