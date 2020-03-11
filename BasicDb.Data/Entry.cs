using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Data
{
    public abstract class Entry
    {
        [Required]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        [ForeignKey(nameof(User))]
        public string AddedBy { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
