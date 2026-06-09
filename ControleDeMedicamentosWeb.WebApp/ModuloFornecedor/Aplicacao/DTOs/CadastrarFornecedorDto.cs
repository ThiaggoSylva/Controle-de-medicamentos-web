namespace ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.DTOs;

public record CadastrarFornecedorDto(
    string Nome,
    string Telefone,
    string Cnpj
);