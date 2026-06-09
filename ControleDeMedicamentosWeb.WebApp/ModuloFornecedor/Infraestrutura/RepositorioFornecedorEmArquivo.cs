using ControleMedicamentosWeb.Compartilhado;
using ControleMedicamentosWeb.ModuloFornecedor.Dominio;

namespace ControleMedicamentosWeb.ModuloFornecedor.Infraestrutura;

public class RepositorioFornecedorEmArquivo
    : RepositorioBaseEmArquivo<Fornecedor>,
      IRepositorioFornecedor
{
    public RepositorioFornecedorEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<Fornecedor> ObterRegistros()
    {
        return contexto.Dados.Fornecedores;
    }

    public bool ExisteCnpj(string cnpj)
    {
        return contexto.Dados.Fornecedores
            .Any(f =>
                f.Cnpj.Equals(
                    cnpj,
                    StringComparison.OrdinalIgnoreCase));
    }

    public bool ExisteCnpj(
        Guid id,
        string cnpj)
    {
        return contexto.Dados.Fornecedores
            .Any(f =>
                f.Id != id &&
                f.Cnpj.Equals(
                    cnpj,
                    StringComparison.OrdinalIgnoreCase));
    }
}