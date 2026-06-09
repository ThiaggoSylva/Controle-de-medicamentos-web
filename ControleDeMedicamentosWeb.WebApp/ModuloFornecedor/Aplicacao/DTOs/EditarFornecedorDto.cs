namespace ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.DTOs;

public record EditarFornecedorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cnpj
);