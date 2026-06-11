using ControleMedicamentosWeb.Compartilhado;

using ControleMedicamentosWeb.ModuloRequisicaoSaida.Dominio;

namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Infraestrutura;

public class RepositorioRequisicaoSaidaEmArquivo
    : RepositorioBaseEmArquivo<RequisicaoSaida>,
      IRepositorioRequisicaoSaida
{
    public RepositorioRequisicaoSaidaEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<RequisicaoSaida> ObterRegistros()
    {
        return contexto.Dados.RequisicoesSaida;
    }
}