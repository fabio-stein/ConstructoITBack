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
    public class FamiliaController : ControllerBase
    {
        private IServiceProvider _serviceProvider;

        public FamiliaController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // GET: api/<FamiliaController>
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                return Ok(context.Familia.ToList());
            }
        }

        // GET api/<FamiliaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                var item = context.Familia.Find(id);
                if (item != null)
                    return Ok(item);
                else
                    return NotFound();
            }
        }

        // POST api/<FamiliaController>
        [HttpPost]
        public IActionResult Post([FromBody] Familia data)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                context.Familia.Add(data);
                context.SaveChanges();
                return Ok(data);
            }
        }

        // PUT api/<FamiliaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Familia value)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                value.Id = id;
                context.Familia.Update(value);
                context.SaveChanges();
            }
        }

        // DELETE api/<FamiliaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context = _serviceProvider.GetRequiredService<DataContext>())
            {
                var item = context.Familia.Find(id);
                if (item == null)
                    return NotFound();
                else
                    context.Familia.Remove(item);

                context.SaveChanges();
                return Ok();
            }
        }
    }
}
