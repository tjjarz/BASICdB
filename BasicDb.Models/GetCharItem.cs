using BasicDb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    public class GetCharItem
    {
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public List<Item> CharItems { get; set; }

        //[ForeignKey(nameof(Item))]
        //public int ItemId { get; set; }
        //public virtual Item Item { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
