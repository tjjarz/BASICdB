using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    public class CharCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "Reign in the verbosity, please.")]
        public string Name { get; set; }

        [MaxLength(500)]
        public string ShortDescription { get; set; }

        [MaxLength(16000)]
        public string Description { get; set; }
    }

    public class CharEdit
    {
        public int CharId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

    }

    public class CharDetail
    {
        public int CharId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        //saved for later
        //public virtual List<Item> Item { get; set; }
        //public virtual List<Media> Media { get; set; }
        //public string UserId { get; set; }

    }

    public class CharListItem
    {
        public int CharId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
    }
}
