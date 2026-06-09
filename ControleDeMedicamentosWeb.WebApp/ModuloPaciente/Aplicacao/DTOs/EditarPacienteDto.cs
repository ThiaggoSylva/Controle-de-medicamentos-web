namespace ControleMedicamentosWeb.ModuloPaciente.Aplicacao.DTOs;

public record EditarPacienteDto(
    Guid Id,
    string Nome,
    string Telefone,
    string CartaoSus,
    string Cpf
);