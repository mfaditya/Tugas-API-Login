using API.Context;
using API.Handlers;
using API.Models;
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
        MyContext myContext;

        public AccountController(MyContext context)
        {
            this.myContext = context;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            var result = myContext.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            var validatePass = Hashing.ValidatePassword(password, result.Password);

            if (result != null && validatePass)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Kamu Berhasil Login"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 400,
                    Message = "Email atau Password Anda Salah!",
                    Data = result
                });
            }
        }

        [HttpPost]
        public ActionResult Register(string fullName, string email, DateTime birthDate, string password)
        {
            Employee employee = new Employee()
            {
                FullName = fullName,
                Email = email,
                BirthDate = birthDate
            };
            myContext.Employees.Add(employee);
            var data = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email));
            if (data == null)
            {
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    var id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                    User user = new User()
                    {
                        Id = id,
                        Password = Hashing.HashPassword(password),
                        RoleId = 1
                    };
                    myContext.Users.Add(user);
                    var resultUser = myContext.SaveChanges();
                    if (resultUser > 0)
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Kamu Berhasil Login"
                        });
                }
            }
            return Ok(new
            {
                StatusCode = 400,
                Message = "Email atau Password Anda Salah!",
                Data = data
            });
        }
    }
}

