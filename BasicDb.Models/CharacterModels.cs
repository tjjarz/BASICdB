using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    public class CharacterCreate
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

    public class CharacterEdit
    {

    }
}
