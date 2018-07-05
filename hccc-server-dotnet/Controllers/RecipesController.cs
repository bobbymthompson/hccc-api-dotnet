using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hccc_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<dynamic>> Get()
        {
            return _context.Set<Recipe>()
                .Include(r => r.Ingredients)
                .Include(r => r.Directions)
                .Select(r => new
                {
                    r.ID,
                    r.Name,
                    r.Category,
                    r.SubCategory,
                    r.Servings,
                    r.CreatedDate,
                    r.RevisionDate,
                    Ingredients = r.Ingredients.Select(i => new { i.Text }),
                    Directions = r.Directions.Select(i => new { i.Text })
                }).ToList();
        }

        // GET api/recipes/5
        [HttpGet("{id}")]
        public ActionResult<dynamic> Get(long id)
        {
            var recipe = _context.Set<Recipe>()
                .Include(r => r.Ingredients)
                .Include(r => r.Directions)
                .Where(r => r.ID == id)
                .Select(r => new
                {
                    r.ID,
                    r.Name,
                    r.Category,
                    r.SubCategory,
                    r.Servings,
                    r.CreatedDate,
                    r.RevisionDate,
                    Ingredients = r.Ingredients.Select(i => new { i.Text }),
                    Directions = r.Directions.Select(i => new { i.Text })
                })
                .FirstOrDefault();

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
            throw new NotImplementedException();
        }

        // PUT api/recipes/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/recipes/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
