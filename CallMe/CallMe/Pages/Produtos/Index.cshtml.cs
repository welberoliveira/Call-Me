using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CallMe.Models;
using System.Globalization;


namespace CallMe.Pages.Produtos
{
    public class IndexModel : PageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;

        public IndexModel(CallMe.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Produto> Produtos { get;set; } = default!;
        public Produto Produto { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Produtos != null)
            {
                Produtos = await _context.Produtos
                .Include(d => d.Categoria).ToListAsync();
            }
        }
    }
}
