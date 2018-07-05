using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hccc_api.Models
{
    public class ShoppingListItem
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RevisionDate { get; set; }
    }
}
