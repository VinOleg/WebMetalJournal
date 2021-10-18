using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMetalJournal.Models
{
    /// <summary>
    /// Номенклатура
    /// </summary>
    public class NomenclatureDir
    {
        [Key]
        public int Number { get; set; }
        public double MaxDeviat { get; set; }
    }
}
