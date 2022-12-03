using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CallMe.Models;
using Microsoft.EntityFrameworkCore;

namespace CallMe.Pages.Pessoas
{
    public class DeleteModel : PageModel
    {
        private readonly CallMe.Data.ApplicationDbContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(CallMe.Data.ApplicationDbContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Pessoa Pessoa { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pessoa = await _context.Pessoas
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Pessoa == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Pessoa = await _context.Pessoas.FindAsync(id);

            if (Pessoa == null)
            {
                return NotFound();
            }

            try
            {
                _context.Pessoas.Remove(Pessoa);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
