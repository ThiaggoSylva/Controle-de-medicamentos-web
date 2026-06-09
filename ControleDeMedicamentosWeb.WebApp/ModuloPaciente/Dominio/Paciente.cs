using ControleMedicamentosWeb.Compartilhado;

namespace ControleMedicamentosWeb.ModuloPaciente.Dominio;

public class Paciente
    : EntidadeBase<Paciente>
{
    public string Nome { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string CartaoSus { get; set; } = string.Empty;

    public string Cpf { get; set; } = string.Empty;

    public override void AtualizarRegistro(
        Paciente registroEditado)
    {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        CartaoSus = registroEditado.CartaoSus;
        Cpf = registroEditado.Cpf;
    }
}