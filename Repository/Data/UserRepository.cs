using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repository.Data
{
    public class UserRepository : IRepository<User, Key>
    {
        private MyContext _context;
        public UserRepository(MyContext context)
        {
            _context = context;
        }
        public int Create(User entity)
        {
            _context.Users.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Delete(Key id)
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

        public User GetById(Key id)
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
