using ControleMedicamentosWeb.Compartilhado;

namespace ControleMedicamentosWeb.ModuloPaciente.Dominio;

public interface IRepositorioPaciente
    : IRepositorioBase<Paciente>
{
    bool ExisteCartaoSus(string cartaoSus);

    bool ExisteCartaoSus(
        Guid id,
        string cartaoSus);
}