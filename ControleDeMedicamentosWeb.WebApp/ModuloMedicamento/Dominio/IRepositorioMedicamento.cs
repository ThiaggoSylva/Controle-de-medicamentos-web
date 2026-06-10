using ControleMedicamentosWeb.Compartilhado;

namespace ControleMedicamentosWeb.ModuloMedicamento.Dominio;

public interface IRepositorioMedicamento
    : IRepositorioBase<Medicamento>
{
    bool ExisteMedicamento(
        string nome);

    Medicamento? SelecionarPorNome(
        string nome);
}