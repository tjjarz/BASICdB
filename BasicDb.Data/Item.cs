using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Data
{
    public class Item : Entry
    {
        [Key]
        public int ItemId { get; set; }

        //[Required]
        //public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        
        /* should now be inherited from entry
        public string AddedBy { get; set; }
        [ForeignKey(nameof(AddedBy))]
        public virtual ApplicationUser User { get; set; }*/

    }
}
