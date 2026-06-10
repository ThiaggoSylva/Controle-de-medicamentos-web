namespace ControleMedicamentosWeb.ModuloMedicamento.Apresentacao.Models;

public class VisualizarMedicamentoViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public int QuantidadeEstoque { get; set; }

    public Guid FornecedorId { get; set; }

    public string NomeFornecedor { get; set; } = string.Empty;

    public bool EmFalta { get; set; }
}