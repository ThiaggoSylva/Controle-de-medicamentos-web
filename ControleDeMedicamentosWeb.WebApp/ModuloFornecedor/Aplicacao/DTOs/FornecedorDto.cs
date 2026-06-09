namespace ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.DTOs;

public record FornecedorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cnpj
);