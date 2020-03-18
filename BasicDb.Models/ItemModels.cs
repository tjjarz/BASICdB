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
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

    }

    public class ItemGetAll
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string AddedBy { get; set; }
    }

    public class ItemEdit
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }

    public class ItemDetail
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<CharListItem> Characters { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }

    }
}
