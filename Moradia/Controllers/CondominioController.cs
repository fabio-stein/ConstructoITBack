using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moradia.Data;
using Moradia.Data.Model;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moradia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondominioController : ControllerBase
    {
        private IServiceProvider _serviceProvider;

        public CondominioController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // GET: api/<CondominioController>
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                return Ok(context.Condominio.ToList());
            }
        }

        // GET api/<CondominioController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                var item = context.Condominio.Find(id);
                if (item != null)
                    return Ok(item);
                else
                    return NotFound();
            }
        }

        // POST api/<CondominioController>
        [HttpPost]
        public IActionResult Post([FromBody] Condominio data)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                context.Condominio.Add(data);
                context.SaveChanges();
                return Ok(data);
            }
        }

        // PUT api/<CondominioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Condominio value)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                value.Id = id;
                context.Condominio.Update(value);
                context.SaveChanges();
            }
        }

        // DELETE api/<CondominioController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                var item = context.Condominio.Find(id);
                if (item == null)
                    return NotFound();
                else
                    context.Condominio.Remove(item);

                context.SaveChanges();
                return Ok();
            }
        }
    }
}
