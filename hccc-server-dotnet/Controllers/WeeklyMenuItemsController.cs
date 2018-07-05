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
    public class WeeklyMenuItemsController : Controller
    {
        private HcccServerDbContext _context = null;

        public WeeklyMenuItemsController(HcccServerDbContext context)
        {
            _context = context;
        }

        // GET api/weeklymenuitems
        [HttpGet]
        public ActionResult<IEnumerable<dynamic>> Get()
        {
            return _context.Set<WeeklyMenuItem>()
                .Select(wmi => new
                {
                    wmi.ID,
                    wmi.Date,
                    wmi.Recipe
                }).ToList();
        }

        // GET api/weeklymenuitems/05-21-2018
        [HttpGet("{date}")]
        public ActionResult<IEnumerable<dynamic>> Get(string date)
        {
            DateTime minDate = Convert.ToDateTime(date);
            DateTime maxDate = minDate.AddDays(7);

            var found = _context.Set<WeeklyMenuItem>()
                .Select(wmi => new
                {
                    wmi.ID,
                    wmi.Date,
                    wmi.Recipe
                })
                .Where(wmi => wmi.Date >= minDate && wmi.Date <= maxDate)
                .ToList();

            if (found == null)
            {
                return NotFound();
            }

            return found;
        }

        public class WMI
        {
            public DateTime Date { get; set; }
            public long Recipe { get; set; }
        }

        // POST api/weeklymenuitems
        [HttpPost]
        public ActionResult<dynamic> Post([FromBody] WMI wmi)
        {
            var newWmi = new WeeklyMenuItem
            {
                Date = wmi.Date,
                Recipe = _context.Set<Recipe>().Find(wmi.Recipe)
            };

            _context.Add(newWmi);

            _context.SaveChanges();

            return newWmi;
        }

        // PUT api/weeklymenuitems/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/recipes/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            var wmi = _context.Set<WeeklyMenuItem>().Find(id);

            if (wmi == null)
            {
                NotFound();
            }
            else
            {
                _context.Set<WeeklyMenuItem>().Remove(wmi);
                _context.SaveChanges();

                this.StatusCode(200);
            }
        }
    }
}