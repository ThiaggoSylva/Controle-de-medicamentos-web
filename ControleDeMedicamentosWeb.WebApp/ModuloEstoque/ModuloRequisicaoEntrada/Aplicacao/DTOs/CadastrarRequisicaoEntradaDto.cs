namespace ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.DTOs;

public record CadastrarRequisicaoEntradaDto(
    DateTime Data,
    Guid MedicamentoId,
    Guid FuncionarioId,
    int Quantidade
);