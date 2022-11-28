using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class RoleRepository : IRepository<Role>
    {
        private MyContext _context;
        public RoleRepository(MyContext context)
        {
            _context = context;
        }

        public int Create(Role entity)
        {
            _context.Roles.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            var check = _context.Roles.Find(id);
            if (check != null)
            {
                _context.Remove(check);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }

        public IEnumerable<Role> Get()
        {
            return _context.Roles.ToList();
        }

        public Role GetById(int id)
        {
            return _context.Roles.Find(id);
        }

        public int Update(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }
    }
}
