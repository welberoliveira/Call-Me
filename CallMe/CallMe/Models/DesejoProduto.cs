using System.ComponentModel.DataAnnotations;

namespace CallMe.Models; 

public enum StatusDesejoProduto
{
    Informações, Compra, NegociaçãoDívida, Cancelamento
}

public class DesejoProduto //enrollment
{
    public int ID { get; set; }
    public int ProdutoID { get; set; }
    public int PessoaID { get; set; }
    [DisplayFormat(NullDisplayText = "Sem Status")]
    public StatusDesejoProduto? StatusDesejoProduto { get; set; }

    [Display(Name = "Produto")]
    public Produto Produto { get; set; }
        
    [Display(Name = "Pessoa")]
    public Pessoa Pessoa { get; set; }
}

