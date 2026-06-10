using ControleMedicamentosWeb.Compartilhado;

namespace ControleMedicamentosWeb.ModuloFuncionario.Dominio;

public class Funcionario
    : EntidadeBase<Funcionario>
{
    public string Nome { get; set; } = string.Empty;

    public string Telefone { get; set; } = string.Empty;

    public string CPF { get; set; } = string.Empty;

    public override void AtualizarRegistro(
        Funcionario registroEditado)
    {
        Nome = registroEditado.Nome;
        Telefone = registroEditado.Telefone;
        CPF = registroEditado.CPF;
    }
}