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
        public string AddedBy { get; set; }
        //public virtual ApplicationUser User { get; set; }
    }

    public class ItemGetAll
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string AddedBy { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
    }

    public class ItemEdit
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }
    }

    public class ItemDetail
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int ItemId { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
    }
}
