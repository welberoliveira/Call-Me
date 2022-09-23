using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CallMe.Models;

public class Produto // course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "Código")]
    public int ID { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    public string? Observacao { get; set; }

    [Required]
    public int CategoriaID { get; set; }

    public Categoria Categoria { get; set; }
    public ICollection<DesejoProduto> DesejoProdutos { get; set; }
}
