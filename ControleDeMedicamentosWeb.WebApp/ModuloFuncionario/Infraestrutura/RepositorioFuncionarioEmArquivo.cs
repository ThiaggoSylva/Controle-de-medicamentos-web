using ControleMedicamentosWeb.Compartilhado;
using ControleMedicamentosWeb.ModuloFuncionario.Dominio;

namespace ControleMedicamentosWeb.ModuloFuncionario.Infraestrutura;

public class RepositorioFuncionarioEmArquivo
    : RepositorioBaseEmArquivo<Funcionario>,
      IRepositorioFuncionario
{
    public RepositorioFuncionarioEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<Funcionario> ObterRegistros()
    {
        return contexto.Dados.Funcionarios;
    }

    public bool ExisteCPF(string cpf)
    {
        return contexto.Dados.Funcionarios
            .Any(f => f.CPF == cpf);
    }

    public Funcionario? SelecionarPorCPF(
        string cpf)
    {
        return contexto.Dados.Funcionarios
            .FirstOrDefault(f => f.CPF == cpf);
    }
}