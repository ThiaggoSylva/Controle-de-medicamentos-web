using ControleMedicamentosWeb.Compartilhado;
using ControleMedicamentosWeb.ModuloMedicamento.Dominio;

namespace ControleMedicamentosWeb.ModuloMedicamento.Infraestrutura;

public class RepositorioMedicamentoEmArquivo
    : RepositorioBaseEmArquivo<Medicamento>,
      IRepositorioMedicamento
{
    public RepositorioMedicamentoEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<Medicamento> ObterRegistros()
    {
        return contexto.Dados.Medicamentos;
    }

    public bool ExisteMedicamento(
        string nome)
    {
        return contexto.Dados.Medicamentos
            .Any(m =>
                m.Nome.Equals(
                    nome,
                    StringComparison.OrdinalIgnoreCase));
    }

    public Medicamento? SelecionarPorNome(
        string nome)
    {
        return contexto.Dados.Medicamentos
            .FirstOrDefault(m =>
                m.Nome.Equals(
                    nome,
                    StringComparison.OrdinalIgnoreCase));
    }
}