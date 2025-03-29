using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavegaTeus.Database.Models
{
    public class PagesModel
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public bool AutoUpdate { get; set; }
        public TimeSpan UpdateFrequency { get; set; }
        public int IndexPosition { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
