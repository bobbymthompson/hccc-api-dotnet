using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hccc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private HcccServerDbContext _context = null;

        public RecipesController(HcccServerDbContext context)
        {
            _context = context;
        }

        // GET api/recipes
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> Get()
        {
            return _context.Set<Recipe>().ToList();
        }

        // GET api/recipes/5
        [HttpGet("{id}")]
        public ActionResult<Recipe> Get(long id)
        {
            var recipe = _context.Set<Recipe>().Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // POST api/recipes
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/recipes/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] string value)
        {
        }

        // DELETE api/recipes/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }
    }
}
