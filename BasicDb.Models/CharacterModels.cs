using BasicDb.Data;
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


    // perhaps these should not actually inherit Entry but should instead 
    // have that information converted into a string at modeling?

    public class CharDetail
    {
        public int CharId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public List<ItemDetail> Items { get; set; }
        public List<MediaShort> Media { get; set; }
        public string AddedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

    }

    public class CharListItem
    {
        public int CharId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }

        
    }
}
