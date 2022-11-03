using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class RoleRepository : IRepository<User, int>
    {
        private MyContext _context;
        public RoleRepository(MyContext context)
        {
            _context = context;
        }
        public int Create(User entity)
        {
            _context.Users.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var check = _context.Users.Find(id);
            if (check != null)
            {
                _context.Remove(check);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public int Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }
    }
}
