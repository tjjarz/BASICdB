using BasicDb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    //POST
    public class MediaCreate
    {
        public int MediaId { get; set; }
        public string Title { get; set; }
        public MediaType Medium { get; set; }
        public string Description { get; set; }
    }
    
    //GET
    public class MediaGet
    {
        public int MediaId { get; set; }
        public string Title { get; set; }
        public MediaType Medium { get; set; }
        public string Description { get; set; }
    }

    //UPDATE
    public class MediaUpdate
    {
        public int MediaId { get; set; }
        public string Title { get; set; }
        public MediaType Medium { get; set; }
        public string Description { get; set; }
    }

    
}
