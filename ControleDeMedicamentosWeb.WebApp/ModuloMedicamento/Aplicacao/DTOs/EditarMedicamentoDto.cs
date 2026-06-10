namespace ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.DTOs;

public record EditarMedicamentoDto(
    Guid Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    Guid FornecedorId
);