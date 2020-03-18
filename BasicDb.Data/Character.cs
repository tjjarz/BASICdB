using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Data
{
    public class Character : Entry
    {
        [Key]
        public int CharId { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public string Description { get; set; }

    }
}