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

        public virtual List<CharItem> CharItems { get; set; }

        public virtual List<CharMedia> CharMedia { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
