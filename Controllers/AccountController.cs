using System.Security.Claims;
using API.Context;
using API.Handlers;
using API.Models;
using API.Repository.Data;
using API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private AccountRepository _repositoryController;
        public AccountController(AccountRepository repositoryRepository)
        {
            _repositoryController = repositoryRepository;
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
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Kamu Berhasil Login",
                        Data = new
                        {
                            Id = Convert.ToInt32(data[0]),
                            Email = (data[1]),
                            FullName = (data[2]),
                            Role = (data[3])
                        }
                    });
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

