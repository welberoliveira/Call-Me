using CallMe.Data;
using CallMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CallMe.Pages.Categorias
{
    public class IndexModel : PageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;

        public IndexModel(CallMe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Categoria> Categorias { get; set; } = default!;
        public Categoria Categoria { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Categorias != null)
            {
                Categorias = await _context.Categorias.ToListAsync();
            }
        }
    }
}
