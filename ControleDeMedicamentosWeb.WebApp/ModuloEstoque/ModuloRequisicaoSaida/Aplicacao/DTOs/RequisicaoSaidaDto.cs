namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.DTOs;

public record RequisicaoSaidaDto(
    Guid Id,
    DateTime Data,
    Guid PacienteId,
    Guid MedicamentoId,
    int Quantidade,
    string NomePaciente,
    string NomeMedicamento
);