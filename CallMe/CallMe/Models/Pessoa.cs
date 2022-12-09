using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CallMe.Models;

public class Pessoa //student
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    [Display(Name = "Sobrenome")]
    public string Sobrenome { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
    [Column("FirstName")]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Data de Cadastro")]
    public DateTime DataCadastro { get; set; }
     
    [Display(Name = "Nome completo")]
    public string NomeCompleto
    {
        get
        {
            return Nome + " " + Sobrenome;
        }
    }
    [Display(Name = "Status do Cliente")]
    public int PessoaStatusId { get; set; }
    public PessoaStatus? PessoaStatus { get; set; }
}
