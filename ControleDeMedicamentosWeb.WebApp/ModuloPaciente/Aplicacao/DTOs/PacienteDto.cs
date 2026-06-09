namespace ControleMedicamentosWeb.ModuloPaciente.Aplicacao.DTOs;

public record PacienteDto(
    Guid Id,
    string Nome,
    string Telefone,
    string CartaoSus,
    string Cpf
);