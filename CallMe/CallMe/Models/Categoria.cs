using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CallMe.Models;

public class Categoria //departament
{
    public int ID { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [Display(Name = "Descrição")]
    public string Name { get; set; }

    [DataType(DataType.Currency)]
    [Column(TypeName = "money")]
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Display(Name = "Orçamento Disponível (R$)")]
    [Required(ErrorMessage = "O valor para o Orçamento está incorreto.")]
    public decimal Budget { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                   ApplyFormatInEditMode = true)]
    [Display(Name = "Data de Início")]
    public DateTime StartDate { get; set; }

    public ICollection<Produto> Produtos { get; set; }
}
