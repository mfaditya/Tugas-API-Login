using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class DepartmentRepository : GeneralRepository<Department>
    {
        private MyContext _context;
        public DepartmentRepository(MyContext context) : base(context)
        {
            _context = context;
        }

        ////Get All
        //public IEnumerable<Department> Get()
        //{
        //    return _context.Departments.ToList();
        //}

        ////Get By Id
        //public Department GetById(int id)
        //{
        //    return _context.Departments.Find(id);
        //}

        //public int Create(Department entity)
        //{
        //    _context.Departments.Add(entity);
        //    var result = _context.SaveChanges();
        //    return result;
        //}

        //public int Update(Department entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;
        //    var result = _context.SaveChanges();
        //    return result;
        //}

        //public int Delete(int id)
        //{
        //    var check = _context.Departments.Find(id);
        //    if (check != null)
        //    {
        //        _context.Remove(check);
        //        var result = _context.SaveChanges();
        //        return result;
        //    }
        //    return 0;
        //}
    }
}
