namespace ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.DTOs;

public record RequisicaoEntradaDto(
    Guid Id,
    DateTime Data,
    Guid MedicamentoId,
    Guid FuncionarioId,
    int Quantidade,
    string NomeMedicamento,
    string NomeFuncionario
);