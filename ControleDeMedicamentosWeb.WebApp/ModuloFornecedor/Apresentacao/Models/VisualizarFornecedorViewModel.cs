namespace ControleMedicamentosWeb.ModuloFornecedor.Apresentacao.Models;

public class VisualizarFornecedorViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string Cnpj { get; set; } = string.Empty;
}