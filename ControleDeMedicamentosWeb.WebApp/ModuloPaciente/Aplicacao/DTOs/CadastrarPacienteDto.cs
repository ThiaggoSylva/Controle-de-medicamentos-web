namespace ControleMedicamentosWeb.ModuloPaciente.Aplicacao.DTOs;

public record CadastrarPacienteDto(
    string Nome,
    string Telefone,
    string CartaoSus,
    string Cpf
);