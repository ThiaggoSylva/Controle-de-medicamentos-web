namespace ControleMedicamentosWeb.ModuloPaciente.Apresentacao.Models;

public class VisualizarPacienteViewModel
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string CartaoSus { get; set; } = string.Empty;

    public string Cpf { get; set; } = string.Empty;
}