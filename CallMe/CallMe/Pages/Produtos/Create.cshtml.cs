using CallMe.Data;
using CallMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CallMe.Pages.Produtos
{
    public class CreateModel : CategoriaNomePageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;

        public CreateModel(CallMe.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult OnGet()
        {
            var CategoriasQuery = _context.Categorias
                                  .Select (a => new {a.Id, a.Nome });
            CategoriaNomeSelect = new SelectList(CategoriasQuery, "Id", "Nome");

            return Page();
        }

        [BindProperty]
        public Produto Produto { get; set; }
        public SelectList CategoriaNomeSelect { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProduto = new Produto();

            if (await TryUpdateModelAsync<Produto>(
                emptyProduto,
                "Produto",   // Prefix for form value.
                s => s.Categoria, s => s.Nome, s => s.Observacao, s => s.CategoriaID))
            {
                _context.Produtos.Add(emptyProduto);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
