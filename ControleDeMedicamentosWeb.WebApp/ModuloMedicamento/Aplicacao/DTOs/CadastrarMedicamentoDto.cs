namespace ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.DTOs;

public record CadastrarMedicamentoDto(
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    Guid FornecedorId
);