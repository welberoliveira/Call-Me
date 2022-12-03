using CallMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CallMe.Pages.Categorias
{
    public class CreateModel : PageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;
        public CreateModel(CallMe.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Categoria Categoria { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCategoria = new Categoria();

            if (await TryUpdateModelAsync<Categoria>(
                emptyCategoria,
                "Categoria",   // Prefix for form value.
                s => s.Nome, s => s.Observacao))
            {
                _context.Categorias.Add(emptyCategoria);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
