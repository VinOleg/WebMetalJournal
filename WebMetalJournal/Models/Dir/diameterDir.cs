using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMetalJournal.Models
{
    public class diameterDir
    {
        [Key]
        public int Id { get; set; }
        public double diam { get; set; }
    }
}
