namespace ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.DTOs;

public record MedicamentoDto(
    Guid Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    Guid FornecedorId,
    string NomeFornecedor,
    bool EmFalta
);