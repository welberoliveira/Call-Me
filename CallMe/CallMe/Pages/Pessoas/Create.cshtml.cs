using CallMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var StatusQuery = _context.PessoaStatuss
                                 .Select(a => new { a.Id, a.Nome });
            StatusNomeSelect = new SelectList(StatusQuery, "Id", "Nome");
            
            return Page();
        }

        [BindProperty]
        public Pessoa Pessoa { get; set; }
        public SelectList StatusNomeSelect { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyPessoa = new Pessoa();

            if (await TryUpdateModelAsync<Pessoa>(
                emptyPessoa,
                "pessoa",   // Prefix for form value.
                s => s.Nome, s => s.Sobrenome, s => s.DataCadastro, s => s.PessoaStatusId))
            {
                _context.Pessoas.Add(emptyPessoa);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
