using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CallMe.Models;

public class Produto // course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "Código")]
    public int CourseID { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [Display(Name = "Descrição")]
    public string Title { get; set; }

    [Range(0, 5)]
    [Display(Name = "Créditos")]
    public int Credits { get; set; }

    public int StatusID { get; set; }

    public Categoria Categoria { get; set; }
    public ICollection<DesejoProduto> DesejoProdutos { get; set; }
}
