using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    public class EditCharItem
    {
        [Key]
        public int CharItemId { get; set; }

        [Required]
        public int CharId { get; set; }

        [Required]
        public int ItemId { get; set; }
    }
}
