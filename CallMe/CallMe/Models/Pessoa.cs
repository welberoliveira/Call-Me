using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CallMe.Models;

public enum Status
{
    Prospect, Lead, Cliente, PosVenda, Desistiu
}
public class Pessoa //student
{
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Sobrenome")]
    public string LastName { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    [Column("FirstName")]
    [Display(Name = "Nome")]
    public string FirstMidName { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Data de matrícula")]
    public DateTime EnrollmentDate { get; set; }

    [DisplayFormat(NullDisplayText = "Sem Status")]
    public Status? Status { get; set; }

    [Display(Name = "Nome completo")]
    public string FullName
    {
        get
        {
            return FirstMidName + " " + LastName;
        }
    }

    [Display(Name = "Disciplinas matriculadas")]
    public ICollection<DesejoProduto> DesejoProdutos { get; set; }
}
