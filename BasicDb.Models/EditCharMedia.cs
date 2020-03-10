using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    public class EditCharMedia
    {
        [Key]
        public int CharMediaId { get; set; }

        [Required]
        public int CharId { get; set; }

        [Required]
        public int MediaId { get; set; }
    }
}
