using BasicDb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    public class ItemCreate
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //[ForeignKey(nameof(User))]
        public string UserId { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }
}
