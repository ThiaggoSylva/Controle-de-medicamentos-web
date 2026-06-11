namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Apresentacao.Models;

public class VisualizarRequisicaoSaidaViewModel
{
    public Guid Id { get; set; }

    public DateTime Data { get; set; }

    public string NomePaciente { get; set; } = string.Empty;

    public string NomeMedicamento { get; set; } = string.Empty;

    public int Quantidade { get; set; }
}