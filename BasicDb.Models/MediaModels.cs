using BasicDb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Models
{
    //should probably add some consitency to whether we call the primary property Title or Name here (though the actual data is stored as .Name)
    //POST
    public class MediaCreate
    {
        public string Name { get; set; }  
        public string MediaType { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
    }
    
    //GET
    public class MediaGet
    {
        public int MediaId { get; set; }
        public string Title { get; set; }
        public string MediaType { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }
    }

    //UPDATE
    public class MediaUpdate
    {
        public int MediaId { get; set; }
        public string Title { get; set; }
        public string MediaType { get; set; }
        public string Description { get; set; }
        public string AddedBy { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }

    public class MediaShort
    {
        public int MediaId { get; set; }
        public string Title { get; set; }
        public string MediaType { get; set; }
        public string AddedBy { get; set; }
    }
}
