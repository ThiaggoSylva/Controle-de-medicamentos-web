using ControleMedicamentosWeb.Compartilhado;

namespace ControleMedicamentosWeb.ModuloFuncionario.Dominio;

public interface IRepositorioFuncionario
    : IRepositorioBase<Funcionario>
{
    bool ExisteCPF(string cpf);

    Funcionario? SelecionarPorCPF(string cpf);
}