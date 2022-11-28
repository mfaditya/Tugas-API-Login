using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repository.Data
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private MyContext _context;
        public EmployeeRepository(MyContext context)
        {
            _context = context;
        }

        public int Create(Employee entity)
        {
            _context.Employees.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var check = _context.Employees.Find(id);
            if (check != null)
            {
                _context.Remove(check);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public IEnumerable<Employee> Get()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public int Update(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }
    }
}
