namespace ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.DTOs;

public record FuncionarioDto(
    Guid Id,
    string Nome,
    string Telefone,
    string CPF
);