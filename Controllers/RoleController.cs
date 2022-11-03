using API.Models;
using API.Repository.Data;
using API.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleRepository _roleRepository;
        public RoleController(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var data = _roleRepository.Get();
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ada"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Ada",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var data = _roleRepository.GetById(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Tidak Ditemukan"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Ditemukan",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public ActionResult Create(Role entity)
        {
            try
            {
                var result = _roleRepository.Create(entity);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Dibuat"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Dibuat",
                        Data = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpPut]
        public ActionResult Update(Role entity)
        {
            try
            {
                var result = _roleRepository.Update(entity);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Di Update"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Di Update",
                        Data = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _roleRepository.Delete(id);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Gagal Dihapus"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data Berhasil Dihapus",
                        Data = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message,
                });
            }
        }
    }
}
