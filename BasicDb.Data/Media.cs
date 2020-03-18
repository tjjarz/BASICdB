    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Data
{
    public class Media : Entry
    {
        [Key]
        public int MediaId { get; set; }

        [Required]
        public string MediaType { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
