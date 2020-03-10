using System;
using System.Collections.Generic;
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
        public string MediaType { get; set; }
        public string MediaDescription { get; set; }
    }
}
