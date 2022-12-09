using CallMe.Data;
using CallMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CallMe.Pages.Produtos
{
    public class CategoriaNomePageModel : PageModel
    {
        /*public SelectList? CategoriaNomeSelect { get; set; }
        public void PopulateCategoriasDropDownList(ApplicationDbContext _context,
            object selectedCategoria = null)
        {
            var CategoriasQuery = from d in _context.Categorias
                                  orderby d.Nome // Sort by name.
                                  select d;

            CategoriaNomeSelect = new SelectList(CategoriasQuery.AsNoTracking(),
                        "CategoriaID", "Nome", selectedCategoria);
        }*/
    }
}