using CallMe.Data;
using CallMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CallMe.Pages.PessoaStatuss
{
    public class IndexModel : PageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;

        public IndexModel(CallMe.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public PessoaStatus PessoaStatus { get; set; }
        public IList<PessoaStatus> PessoaStatuss { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.PessoaStatuss != null)
            {
                PessoaStatuss = await _context.PessoaStatuss.ToListAsync();
            }
        }
    }
}
