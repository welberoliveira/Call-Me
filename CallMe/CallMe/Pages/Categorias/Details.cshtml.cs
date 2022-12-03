using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CallMe.Models;
using Microsoft.EntityFrameworkCore;

namespace CallMe.Pages.Categorias
{
    public class DetailsModel : PageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;
        public DetailsModel(CallMe.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Categoria == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
