using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMetalJournal.Models.ViewModel
{
    public class JournalCreateViewModel
    {
        public IEnumerable<diameterDir> diameterDir { get; set; }
        public Journal Journal { get; set; }
    }
}
