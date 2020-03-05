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
        public int CharMediaID { get; set; }

        public List<Character> Characters { get; set; }

        public List<Media> Media { get; set; }
    }
}
