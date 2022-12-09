using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CallMe.Models;

namespace CallMe.Pages.Categorias
{
    public class EditModel : PageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;

        public EditModel(CallMe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categoria Categoria { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categorias.FindAsync(id);

            if (Categoria == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var CategoriaToUpdate = await _context.Categorias.FindAsync(id);

            if (CategoriaToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Categoria>(
                CategoriaToUpdate,
                "Categoria",
                s => s.Nome, s => s.Observacao))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
