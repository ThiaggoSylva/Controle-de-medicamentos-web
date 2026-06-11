namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.DTOs;

public record CadastrarRequisicaoSaidaDto(
    DateTime Data,
    Guid PacienteId,
    Guid MedicamentoId,
    int Quantidade
);