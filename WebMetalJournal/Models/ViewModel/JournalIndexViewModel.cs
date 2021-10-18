using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMetalJournal.Models.ViewModel
{
    public class JournalIndexViewModel
    {
        public IEnumerable<Journal> Journal { get; set; }
        public int PagingStatus { get; set; }
        public int Page { get; set; }

    }
}
