namespace CallMe.Models;

public class PessoaStatus
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Pessoa> Pessoas { get; set; }
}
