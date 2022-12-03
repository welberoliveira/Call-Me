using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CallMe.Models;
using Microsoft.EntityFrameworkCore;

namespace CallMe.Pages.Pessoas
{
    public class DetailsModel : PageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;
        public DetailsModel(CallMe.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public Pessoa Pessoa { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pessoa = await _context.Pessoas
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Pessoa == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
