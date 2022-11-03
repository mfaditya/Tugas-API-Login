using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repository.Data
{
    public class DivisionRepository : IRepository<Division, int>
    {
        private MyContext _context;
        public DivisionRepository(MyContext context)
        {
            _context = context;
        }

        //Get All
        public IEnumerable<Division> Get()
        {
            return _context.Divisions.ToList();
        }

        //Get By Id
        public Division GetById(int id)
        {
            return _context.Divisions.Find(id);
        }

        //Create
        public int Create(Division entity)
        {
            _context.Divisions.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        //Update
        public int Update(Division entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result;
        }

        //Delete
        public int Delete(int id)
        {
            var check = _context.Divisions.Find(id);
            if (check != null)
            {
                _context.Remove(check);
                var result = _context.SaveChanges();
                return result;
            }
            return 0;
        }
    }
}
