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
        public int CharId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        @ -22,21 +21,5 @@ namespace BasicDb.Models
        public string ItemDescription { get; set; }

        
        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        public List<Item> items { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
