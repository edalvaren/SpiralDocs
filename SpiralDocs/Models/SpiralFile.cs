using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpiralDocs.Models
{
    public class SpiralFile
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Topic { get; set; }

        public string Category { get; set; }

        public string Url { get; set; }

        public string LastUpdate { get; set; }
    }
}
