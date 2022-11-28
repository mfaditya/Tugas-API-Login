using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : BaseController<DivisionRepository, Division>
    {
        private DivisionRepository _repository;

        public DivisionController(DivisionRepository divisionRepository) : base(divisionRepository)
        {
            _repository = divisionRepository;
        }

        //    [HttpGet]
        //    public ActionResult GetAll()
        //    {
        //        try
        //        {
        //            var data = _repository.Get();
        //            if (data == null)
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Tidak Ada"
        //                });
        //            }
        //            else
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Ada",
        //                    Data = data
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(new
        //            {
        //                StatusCode = 400,
        //                Message = ex.Message,
        //            });
        //        }
        //    }

        //    [HttpGet("{id}")]
        //    public ActionResult GetById(int id)
        //    {
        //        try
        //        {
        //            var data = _repository.GetById(id);
        //            if (data == null)
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Tidak Ditemukan"
        //                });
        //            }
        //            else
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Ditemukan",
        //                    Data = data
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(new
        //            {
        //                StatusCode = 400,
        //                Message = ex.Message,
        //            });
        //        }
        //    }

        //    [HttpPost]
        //    public ActionResult Create(Division division)
        //    {
        //        try
        //        {
        //            var result = _repository.Create(division);
        //            if (result == 0)
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Gagal Dibuat"
        //                });
        //            }
        //            else
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Berhasil Dibuat",
        //                    Data = result
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(new
        //            {
        //                StatusCode = 400,
        //                Message = ex.Message,
        //            });
        //        }
        //    }

        //    [HttpPut]
        //    public ActionResult Update(Division division)
        //    {
        //        try
        //        {
        //            var result = _repository.Update(division);
        //            if (result == 0)
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Gagal Di Update"
        //                });
        //            }
        //            else
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Berhasil Di Update",
        //                    Data = result
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(new
        //            {
        //                StatusCode = 400,
        //                Message = ex.Message,
        //            });
        //        }
        //    }

        //    [HttpDelete]
        //    public ActionResult Delete(int id)
        //    {
        //        try
        //        {
        //            var result = _repository.Delete(id);
        //            if (result == 0)
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Gagal Dihapus"
        //                });
        //            }
        //            else
        //            {
        //                return Ok(new
        //                {
        //                    StatusCode = 200,
        //                    Message = "Data Berhasil Dihapus",
        //                    Data = result
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(new
        //            {
        //                StatusCode = 400,
        //                Message = ex.Message,
        //            });
        //        }
        //    }
        //}
    }
}
