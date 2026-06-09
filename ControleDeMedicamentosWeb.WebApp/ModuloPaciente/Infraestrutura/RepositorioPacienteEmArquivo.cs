using ControleMedicamentosWeb.Compartilhado;
using ControleMedicamentosWeb.ModuloPaciente.Dominio;

namespace ControleMedicamentosWeb.ModuloPaciente.Infraestrutura;

public class RepositorioPacienteEmArquivo
    : RepositorioBaseEmArquivo<Paciente>,
      IRepositorioPaciente
{
    public RepositorioPacienteEmArquivo(
        ContextoJson contexto)
        : base(contexto)
    {
    }

    protected override List<Paciente> ObterRegistros()
    {
        return contexto.Dados.Pacientes;
    }

    public bool ExisteCartaoSus(
        string cartaoSus)
    {
        return contexto.Dados.Pacientes
            .Any(p =>
                p.CartaoSus.Equals(
                    cartaoSus,
                    StringComparison.OrdinalIgnoreCase));
    }

    public bool ExisteCartaoSus(
        Guid id,
        string cartaoSus)
    {
        return contexto.Dados.Pacientes
            .Any(p =>
                p.Id != id &&
                p.CartaoSus.Equals(
                    cartaoSus,
                    StringComparison.OrdinalIgnoreCase));
    }
}