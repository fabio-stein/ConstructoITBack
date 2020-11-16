using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moradia.Data;
using Moradia.Data.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Moradia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        // GET: api/<FamiliaController>
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new DataContext())
            {
                return Ok(context.Familia.ToList());
            }
        }

        // GET api/<FamiliaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (var context = new DataContext())
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
            using (var context = new DataContext())
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
            using (var context = new DataContext())
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
            using (var context = new DataContext())
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
