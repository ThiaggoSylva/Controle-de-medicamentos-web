using ControleMedicamentosWeb.Compartilhado;

using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Dominio;

namespace ControleMedicamentosWeb.ModuloRequisicaoEntrada.Infraestrutura;

public class RepositorioRequisicaoEntradaEmArquivo
    : RepositorioBaseEmArquivo<RequisicaoEntrada>,
      IRepositorioRequisicaoEntrada
{
    public RepositorioRequisicaoEntradaEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<RequisicaoEntrada> ObterRegistros()
    {
        return contexto.Dados.RequisicoesEntrada;
    }
}