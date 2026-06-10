using ControleMedicamentosWeb.Compartilhado;
using ControleMedicamentosWeb.ModuloFornecedor.Dominio;

namespace ControleMedicamentosWeb.ModuloMedicamento.Dominio;

public class Medicamento
    : EntidadeBase<Medicamento>
{
    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public int QuantidadeEstoque { get; set; }

    public Guid FornecedorId { get; set; }

    public Fornecedor? Fornecedor { get; set; }

    public bool EmFalta =>
        QuantidadeEstoque < 20;

    public override void AtualizarRegistro(
        Medicamento registroEditado)
    {
        Nome = registroEditado.Nome;
        Descricao = registroEditado.Descricao;
        QuantidadeEstoque = registroEditado.QuantidadeEstoque;
        FornecedorId = registroEditado.FornecedorId;
    }
}