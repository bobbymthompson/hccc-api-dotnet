using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hccc_api;
using hccc_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hccc_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListItemsController : Controller
    {
        private HcccServerDbContext _context = null;

        public ShoppingListItemsController(HcccServerDbContext context)
        {
            _context = context;
        }

        // GET api/shoppinglistitems
        [HttpGet]
        public ActionResult<IEnumerable<dynamic>> Get()
        {
            return _context.Set<ShoppingListItem>()
                .Select(wmi => new
                {
                    wmi.ID,
                    wmi.Text
                }).ToList();
        }

        // GET api/shoppinglistitems/5
        [HttpGet("{id}")]
        public ActionResult<dynamic> Get(long id)
        {
            var found = _context.Set<ShoppingListItem>()
                .Select(sli => new
                {
                    sli.ID,
                    sli.Text
                })
                .Where(sli => sli.ID == id)
                .FirstOrDefault();

            if (found == null)
            {
                return NotFound();
            }

            return found;
        }

        public class SLI
        {
            public string Text { get; set; }
        }

        // POST api/shoppinglistitems
        [HttpPost]
        public ActionResult<dynamic> Post([FromBody] SLI sli)
        {
            var newSli = new ShoppingListItem
            {
                Text = sli.Text
            };

            _context.Add(newSli);

            _context.SaveChanges();

            return newSli;
        }

        // PUT api/shoppinglistitems/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/shoppinglistitems/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            var sli = _context.Set<ShoppingListItem>().Find(id);

            if (sli == null)
            {
                NotFound();
            }
            else
            {
                _context.Set<ShoppingListItem>().Remove(sli);
                _context.SaveChanges();

                this.StatusCode(200);
            }
        }
    }
}