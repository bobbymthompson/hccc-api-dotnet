using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hccc_api.Models
{
    public class Recipe
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Servings { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RevisionDate { get; set; }

        public List<Ingredient> Ingredients { get; set; }
        public List<Direction> Directions { get; set; }
    }
}
