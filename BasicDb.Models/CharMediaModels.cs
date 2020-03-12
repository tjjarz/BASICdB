using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    public class GetCharMedia
    {
        public int CharId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int MediaId { get; set; }
        public string Title { get; set; }
        public string Medium { get; set; }
        public string MediaDescription { get; set; }
    }
    
    public class EditCharMedia
    {
        [Key]
        public int CharMediaId { get; set; }

        [Required]
        public int CharId { get; set; }

        [Required]
        public int MediaId { get; set; }
    }

    public class PostCharMedia
    {
        [Required]
        public int CharId { get; set; }
        [Required]
        public int MediaId { get; set; }
    }
}
