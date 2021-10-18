using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMetalJournal.Models;
using WebMetalJournal.Models.ViewModel;
using WebMetalJournal.Others;

namespace WebMetalJournal.Controllers
{
    #region BaseController
    public class JournalController : Controller
    {
        private LocalDBContext db;
        private readonly ILogger<JournalController> _logger;

        public JournalController(ILogger<JournalController> logger, LocalDBContext context)
        {
            db = context;
            _logger = logger;
        }
        #endregion
        #region OpenViews
        /// <summary>
        /// главная журнала
        /// </summary>
        /// <param name="id">URL идентификатор</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int id = 0)
        {
            //Все журналы
            List<Journal> AllList = await db.Journals.ToListAsync();
            //Все даты
            var dateList = AllList.GroupBy(g => g.CreatedForList.ToString("ddMMyyyy"));
            List<Journal> SortedList = AllList.Where(w => w.CreatedForList.ToString("ddMMyyyy") == dateList.ElementAt(id).Key).ToList();
            // pagingstatus=0 обе стрелки pagingstatus=1 стрелка вправа pagingstatus=2 стрелка влево
            byte pagingstatus =0;
            if (id == 0)
            {
                pagingstatus = 1;
            }
            else if (dateList.Count()-1==id)
            { 
                pagingstatus = 2;
            }


            JournalIndexViewModel ivm = new JournalIndexViewModel { Journal = SortedList, PagingStatus = pagingstatus,Page= id };
            if (AllList.Any())
                return View(ivm);
            else
                return NotFound();
        }
        /// <summary>
        /// Вид создания листа для журнала
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            List <diameterDir> AllDiam = await db.diametersDir.ToListAsync();
            JournalCreateViewModel cvm = new JournalCreateViewModel { Journal = new Journal(), diameterDir= AllDiam };
            return View(cvm);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Journal journal = await db.Journals.FirstOrDefaultAsync(p => p.Id == id);
                if (journal != null)
                { 
                    List<diameterDir> AllDiam = await db.diametersDir.ToListAsync();
                JournalCreateViewModel cvm = new JournalCreateViewModel { Journal = journal, diameterDir = AllDiam };
                    _logger.LogInformation("EDIT " + journal.Id);
                    return View(cvm);
                }
            }
            _logger.LogInformation("Journal IS NULL (edit)");
            return NotFound();
        }

        #endregion
        #region Действия с данными
        /// <summary>
        /// Работа с базой данных при создании
        /// </summary>
        /// <param name="_journal">Модель для ORM</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(JournalCreateViewModel _journal)
        {
            List<NomenclatureDir> AllNomenclature = await db.NomenclaturesDir.ToListAsync();

            if (AllNomenclature.Any(n =>n.Number== _journal.Journal.Nomenclature))
            {
                int TargetNom = _journal.Journal.Nomenclature;
                _journal.Journal.MaxDeviat= AllNomenclature.Where(nom => nom.Number== _journal.Journal.Nomenclature).First().MaxDeviat;
                _journal.Journal.CreatedForList = DateTime.Now;
                db.Journals.Add(_journal.Journal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                List<diameterDir> AllDiam = await db.diametersDir.ToListAsync();
                JournalCreateViewModel cvm = new JournalCreateViewModel { Journal= _journal.Journal, diameterDir = AllDiam };
                ModelState.AddModelError("Journal", "Отсутствует нуменклатура. Проверьте правильность ввода");
                return View(cvm);
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Journal journal)
        {
               db.Journals.Update(journal);
            await db.SaveChangesAsync();
            _logger.LogInformation("EDIT " + journal.Id);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Удаление(удаляет сразу же)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Journal journal = await db.Journals.FirstOrDefaultAsync(p => p.Id == id);
                if (journal != null)
                {
                    _logger.LogInformation("Delete " + journal.Id);
                    db.Journals.Remove(journal);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            _logger.LogError("Jounal IS NULL (delete)");
            return NotFound();
        }
        #endregion
    }
}
