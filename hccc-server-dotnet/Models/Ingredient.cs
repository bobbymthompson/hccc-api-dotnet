using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hccc_api.Models
{
    public class Ingredient
    {
        public long ID { get; set; }
        public Recipe Recipe { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RevisionDate { get; set; }
    }
}
