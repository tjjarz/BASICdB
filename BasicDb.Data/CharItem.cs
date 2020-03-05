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

        public virtual List<Character> Characters { get; set; }

        public virtual List<Item> Items { get; set; }
    }
}
