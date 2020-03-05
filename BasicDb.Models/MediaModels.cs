using BasicDb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    class MediaCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public MediaType Medium { get; set; }

        [Required]
        public string Description { get; set; }
    }

    class MediaEdit
    {
        public int MediaId { get; set; }
        public MediaType Medium { get; set; }
        public string Description { get; set; }
    }
}
