using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Data
{
    public class CharItem
    {
        [Key]
        public int CharItemID { get; set; }

        //[ForeignKey(nameof(Character))]
        //public int CharacterId { get; set; }
        //public virtual Character Character { get; set; }

        ////[ForeignKey("Item")]
        ////public int ItemId { get; set; }
        //public ICollection<Item> Item { get; set; }
    }
}
