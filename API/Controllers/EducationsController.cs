using API.Contexts;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private EducationRepository repository;

        public EducationsController (EducationRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Education entity)
        {
            try
            {
                var results = await repository.Insert(entity);
                if (results == 0)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Data gagal disimpan!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil disimpan!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 500,
                    Message = "Something Wrong " + ex.Message,
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Getall()
        {
            var results = await repository.GetAll();
            if (results is null)
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data kosong!"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data ada!",
                    Data = results
                });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Education entity)
        {
            try
            {
                var results = await repository.Update(entity);
                if (results == 0)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Data gagal disimpan!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil disimpan!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 500,
                    Message = "Something Wrong " + ex.Message,
                });
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int key)
        {
            try
            {
                var results = await repository.Delete(key);
                if (results == 0)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Data gagal disimpan!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil disimpan!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 500,
                    Message = "Something Wrong " + ex.Message,
                });
            }

        }

        [HttpGet]
        [Route("{key}")]

        public async Task<ActionResult> GetById(int key)
        {
            var results = await repository.GetById(key);
            if (results is null)
            {
                return Ok(new
                {
                    StatusCode = 400,
                    Message = "Data kosong!"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data ada!",
                    Data = results
                });
            }
        }
    }
}
