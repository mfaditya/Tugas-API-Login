using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Staff")]
    public class DepartmentController : BaseController<DepartmentRepository, Department>
    {
        private DepartmentRepository _repository;

        public DepartmentController(DepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _repository = departmentRepository;
        }

        //[Authorize]
        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    try
        //    {
        //        var data = Ok(_repository.Get());
        //        if (data == null)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Tidak Ada"
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Ada",
        //                Data = data
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message,
        //        });
        //    }
        //}

        //[HttpGet("{id}")]
        //public ActionResult GetById(int id)
        //{
        //    try
        //    {
        //        var data = _repository.GetById(id);
        //        if (data == null)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Tidak Ditemukan"
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Ditemukan",
        //                Data = data
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message,
        //        });
        //    }
        //}

        //[HttpPost]
        //public ActionResult Create(Department department)
        //{
        //    try
        //    {
        //        var result = _repository.Create(department);
        //        if (result == 0)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Gagal Dibuat"
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Berhasil Dibuat",
        //                Data = result
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message,
        //        });
        //    }
        //}

        //[HttpPut]
        //public ActionResult Update(Department department)
        //{
        //    try
        //    {
        //        var result = _repository.Update(department);
        //        if (result == 0)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 400,
        //                Message = "Data Gagal Di Update"
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Berhasil Di Update",
        //                Data = result
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message,
        //        });
        //    }
        //}

        //[HttpDelete]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        var result = _repository.Delete(id);
        //        if (result == 0)
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Gagal Dihapus"
        //            });
        //        }
        //        else
        //        {
        //            return Ok(new
        //            {
        //                StatusCode = 200,
        //                Message = "Data Berhasil Dihapus",
        //                Data = result
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            StatusCode = 400,
        //            Message = ex.Message,
        //        });
        //    }
        //}
    }
}
