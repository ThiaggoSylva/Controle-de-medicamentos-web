namespace ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.DTOs;

public record EditarFuncionarioDto(
    Guid Id,
    string Nome,
    string Telefone,
    string CPF
);