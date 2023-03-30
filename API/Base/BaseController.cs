using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Key, Entity, Repository> : ControllerBase
        where Entity : class
        where Repository : IRepository<Key, Entity>
    {
        private readonly Repository repository;

        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Entity entity)
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
                    StatusCode = 400,
                    Message = "Something Wrong " + ex.Message,
                });
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Massage = "Something Wrong " + ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(Entity entity)
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
                    StatusCode = 400,
                    Message = "Something Wrong " + ex.Message,
                });
            }
        }
        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete(Key key)
        {
            try
            {
                var results = await repository.Delete(key);
                if (results == 0)
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Data gagal dihapus!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil dihapus!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong " + ex.Message,
                });
            }

        }

        [HttpGet]
        [Route("{key}")]

        public async Task<ActionResult> GetById(Key key)
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