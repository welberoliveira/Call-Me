using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CallMe.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CallMe.Pages.Pessoas
{
    public class EditModel : PageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;

        public EditModel(CallMe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pessoa Pessoa { get; set; } = default!;
        public SelectList StatusNomeSelect { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pessoa = await _context.Pessoas.FindAsync(id);

            if (Pessoa == null)
            {
                return NotFound();
            }

            var StatusQuery = _context.Categorias
                                 .Select(a => new { a.Id, a.Nome });
            StatusNomeSelect = new SelectList(StatusQuery, "Id", "Nome");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var PessoaToUpdate = await _context.Pessoas.FindAsync(id);

            if (PessoaToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Pessoa>(
                PessoaToUpdate,
                "Pessoa",
                s => s.Nome, s => s.Sobrenome, s => s.DataCadastro, s => s.PessoaStatus))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool PessoaExists(int id)
        {
            return _context.Pessoas.Any(e => e.Id == id);
        }
    }
}
