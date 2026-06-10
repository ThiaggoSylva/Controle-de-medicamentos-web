namespace ControleMedicamentosWeb.ModuloFuncionario.Apresentacao.Models;

public class VisualizarFuncionarioViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string CPF { get; set; } = string.Empty;
}