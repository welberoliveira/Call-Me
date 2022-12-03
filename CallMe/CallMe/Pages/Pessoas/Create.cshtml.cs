using CallMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CallMe.Pages.Pessoas
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
        public Pessoa Pessoa { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var emptyPessoa = new Pessoa();

            if (await TryUpdateModelAsync<Pessoa>(
                emptyPessoa,
                "pessoa",   // Prefix for form value.
                s => s.Nome, s => s.Sobrenome, s => s.DataCadastro, s => s.StatusPessoa))
            {
                _context.Pessoas.Add(emptyPessoa);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
