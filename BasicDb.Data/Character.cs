using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Data
{
    public class Character
    {
        [Key]
        public int CharID { get; set; }

        [Required]
        public string Name { get; set; }
        
        /*
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public virtual ICollection<Item> Item { get; set; }

        [ForeignKey(nameof(Media))]
        public int MediaId { get; set; }
        public virtual ICollection<Media> Media { get; set; }
        */

        [Required]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
