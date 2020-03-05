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
        public int CharId { get; set; }

        [Required]
        public string Name { get; set; }


        public virtual List<CharItem> CharItems { get; set; }

        public virtual List<CharMedia> CharMedia { get; set; }

        /* master stuff
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public virtual List<Item> Item { get; set; }
        
        [ForeignKey(nameof(Media))]
        public int MediaId { get; set; }
        public virtual List<Media> Media { get; set; }*/


        [Required]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        //public DateTime CreatedOn { get; set; }
        //public DateTime ModifiedOn { get; set; }
        // add created and updated datetimes!

    }
}
