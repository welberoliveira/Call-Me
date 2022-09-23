using CallMe.Data;
using CallMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CallMe.Pages.Pessoas
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string FirstSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Pessoa> Pessoas { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            // using System;
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            FirstSort = sortOrder == "First" ? "first_desc" : "First";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Pessoa> studentsIQ = from s in _context.Pessoas
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.Sobrenome.Contains(searchString)
                                       || s.Nome.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "First":
                    studentsIQ = studentsIQ.OrderBy(s => s.Nome).ThenBy(s => s.Sobrenome);
                    break;
                case "first_desc":
                    studentsIQ = studentsIQ.OrderByDescending(
                        s => s.NomeCompleto).ThenByDescending(s => s.Sobrenome);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.DataCadastro);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.DataCadastro);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderByDescending(s => s.ID);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Pessoas = await PaginatedList<Pessoa>.CreateAsync
                (
                    studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize
                );
        }
    }
}
