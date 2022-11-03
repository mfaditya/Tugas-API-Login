using API.Context;
using API.Handlers;
using API.Models;
using API.Repository.Interface;
using API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repository.Data
{
    public class AccountRepository
    {
        MyContext _context;
        public AccountRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        [HttpPost]
        public List<string> Login(string email, string password)
        {
            var result = _context.Users
                .Include(x => x.Employee)
                .Include(x => x.Role)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            var validatePass = Hashing.ValidatePassword(password, result.Password);
            if (result != null && validatePass)
            {
                List<string> list = new List<string>(4);
                list.Add(result.Id.ToString());
                list.Add(result.Employee.Email);
                list.Add(result.Employee.FullName);
                list.Add(result.Role.Name);
                return list;
            }
            return null;
        }

        [HttpPost]
        public int Register(string fullName, string email, DateTime birthDate, string password)
        {
            Employee employee = new Employee()
            {
                FullName = fullName,
                Email = email,
                BirthDate = birthDate
            };
            _context.Employees.Add(employee);
            var data = _context.Employees.SingleOrDefault(x => x.Email.Equals(email));
            if (data == null)
            {
                var result = _context.SaveChanges();
                if (result > 0)
                {
                    var id = _context.Employees.SingleOrDefault(x => x.Email.Equals(email)).Id;
                    User user = new User()
                    {
                        Id = id,
                        Password = Hashing.HashPassword(password),
                        RoleId = 1
                    };
                    _context.Users.Add(user);
                    var resultUser = _context.SaveChanges();
                }
                return result;
            }
            return 0;
        }

        [HttpPost]
        public int ChangePassword(string email, string passwordLama, string passwordBaru)
        {
            var data = _context.Users.Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            var validatePass = Hashing.HashPassword(passwordLama);
            if (data != null)
            {
                data.Password = Hashing.HashPassword(passwordBaru);
                _context.Entry(data).State = EntityState.Modified;
                var resultUser = _context.SaveChanges();
            }
            return 0;
        }

        [HttpPost]
        public int ForgotPassword(string email, string passwordBaru)
        {
            var data = _context.Users.Include(x => x.Employee)
                .SingleOrDefault(x => x.Employee.Email.Equals(email));
            if (data != null)
            {
                data.Password = Hashing.HashPassword(passwordBaru);
                _context.Entry(data).State = EntityState.Modified;
                var resultUser = _context.SaveChanges();
            }
            return 0;
        }
    }
}
