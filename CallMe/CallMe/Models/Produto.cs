using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CallMe.Models;

public class Produto 
{
    [Display(Name = "Código")]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    public string? Observacao { get; set; }

    public int? CategoriaID { get; set; }
    public Categoria? Categoria { get; set; }
}
