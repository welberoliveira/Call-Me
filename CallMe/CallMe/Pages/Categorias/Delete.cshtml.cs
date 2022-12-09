using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CallMe.Models;
using Microsoft.EntityFrameworkCore;

namespace CallMe.Pages.Categorias
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
        public Categoria Categoria { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Categoria = await _context.Categorias
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Categoria == null)
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

            var Categoria = await _context.Categorias.FindAsync(id);

            if (Categoria == null)
            {
                return NotFound();
            }

            try
            {
                _context.Categorias.Remove(Categoria);
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
