using CallMe.Models;

namespace CallMe.Data;

public class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        // Look for any students.
        if (context.Pessoas.Any())
        {
            return;   // DB has been seeded
        }


        var pessoaStatuss = new PessoaStatus[]
        {
            new PessoaStatus{Nome = "Prospect" },
            new PessoaStatus{Nome = "Lead" }
        };

        context.PessoaStatuss.AddRange(pessoaStatuss);
        context.SaveChanges();

        var pessoas = new Pessoa[]
        {
                new Pessoa{Nome = "a", Sobrenome = "z", DataCadastro=DateTime.Parse("2019-09-01"), PessoaStatusId = 1},
                new Pessoa{Nome = "b", Sobrenome = "y", DataCadastro=DateTime.Parse("2019-09-01"), PessoaStatusId = 2}
        };

        context.Pessoas.AddRange(pessoas);
        context.SaveChanges();
    }
}
