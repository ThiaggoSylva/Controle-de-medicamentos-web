namespace ControleMedicamentosWeb.ModuloRequisicaoEntrada.Apresentacao.Models;

public class VisualizarRequisicaoEntradaViewModel
{
    public Guid Id { get; set; }

    public DateTime Data { get; set; }

    public string NomeMedicamento { get; set; } = string.Empty;

    public string NomeFuncionario { get; set; } = string.Empty;

    public int Quantidade { get; set; }
}