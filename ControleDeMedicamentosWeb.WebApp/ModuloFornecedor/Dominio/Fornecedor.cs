using ControleMedicamentosWeb.Compartilhado;

namespace ControleMedicamentosWeb.ModuloFornecedor.Dominio;

public class Fornecedor
    : EntidadeBase<Fornecedor>
{
    public string Nome { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string Cnpj { get; set; } = string.Empty;

    public override void AtualizarRegistro(
        Fornecedor registroEditado)
    {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        Cnpj = registroEditado.Cnpj;
    }
}