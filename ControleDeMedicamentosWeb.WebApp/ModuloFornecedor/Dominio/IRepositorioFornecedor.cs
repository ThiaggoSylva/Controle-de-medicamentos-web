using ControleMedicamentosWeb.Compartilhado;

namespace ControleMedicamentosWeb.ModuloFornecedor.Dominio;

public interface IRepositorioFornecedor
    : IRepositorioBase<Fornecedor>
{
    bool ExisteCnpj(string cnpj);

    bool ExisteCnpj(
        Guid id,
        string cnpj);
}