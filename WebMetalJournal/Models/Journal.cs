using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMetalJournal.Models
{
    /// <summary>
    /// Журнал
    /// </summary>
    /// <param name="Number">description</param>

    public class Journal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Номер трубы обязателен")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Номенклатура обязательна")]
        public int Nomenclature { get; set; }
        [Required(ErrorMessage = "Целевой внешний диаметр трубы обязателен")]
        public double TargetOuterD { get; set; }
        [Required(ErrorMessage = "Измеренный внешний диаметр по концу трубы 1 обязателен")]
        public double MeasuredOuterDOne { get; set; }
        [Required(ErrorMessage = "Измеренный внешний диаметр по концу трубы 2 обязателен")]
        public double MeasuredOuterDTwo { get; set; }
        public double MeasuredOuterDNotReq { get; set; }
        [Required(ErrorMessage = "Максимальное отклонение измеренных диаметров от целевого обязательно")]
        public double MaxDeviat { get; set; }
        public string Note { get; set; }
        public DateTime CreatedForList { get; set; }
}
}
