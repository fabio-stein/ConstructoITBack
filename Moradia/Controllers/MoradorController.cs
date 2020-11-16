using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moradia.Data;
using Moradia.Data.Model;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moradia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradorController : ControllerBase
    {
        private DataFactory _dataFactory;
        private IServiceProvider _serviceProvider;

        public MoradorController(DataFactory dataFactory, IServiceProvider serviceProvider)
        {
            _dataFactory = dataFactory;
            _serviceProvider = serviceProvider;
        }

        // GET: api/<MoradorController>
        [HttpGet]
        public IActionResult Get()
        {
            using (var conn = _dataFactory.OpenConnection())
            {
                return Ok(conn.Query("EXEC ConsultaMoradores"));
            }
        }

        // GET api/<MoradorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                var item = context.Morador.Find(id);
                if (item != null)
                    return Ok(item);
                else
                    return NotFound();
            }
        }

        // POST api/<MoradorController>
        [HttpPost]
        public IActionResult Post([FromBody] Morador data)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                context.Morador.Add(data);
                context.SaveChanges();
                return Ok(data);
            }
        }

        // PUT api/<MoradorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Morador value)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                value.Id = id;
                context.Morador.Update(value);
                context.SaveChanges();
            }
        }

        // DELETE api/<MoradorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                var item = context.Morador.Find(id);
                if (item == null)
                    return NotFound();
                else
                    context.Morador.Remove(item);

                context.SaveChanges();
                return Ok();
            }
        }
    }
}
