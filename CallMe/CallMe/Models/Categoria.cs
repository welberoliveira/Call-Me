using System.ComponentModel.DataAnnotations;

namespace CallMe.Models;

public class Categoria //departament
{
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [Display(Name = "Descrição")]
    public string Nome { get; set; }

    public string Observacao { get; set; }

    public ICollection<Produto?> ?Produtos { get; set; }
}
