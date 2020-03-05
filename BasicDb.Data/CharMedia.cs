using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Data
{
    public class CharMedia
    {
        [Key]
        public int CharMediaId { get; set; }

        [ForeignKey(nameof(Character))]
        public int CharId { get; set; }
        public virtual Character Character { get; set; }

        [ForeignKey(nameof(Media))]
        public int MediaId { get; set; }
        public virtual Media Media { get; set; }
    }
}
