using ControleMedicamentosWeb.Compartilhado;

namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Dominio;

public class RequisicaoSaida
    : EntidadeBase<RequisicaoSaida>
{
    public DateTime Data { get; set; }

    public Guid PacienteId { get; set; }

    public Guid MedicamentoId { get; set; }

    public int Quantidade { get; set; }

    public override void AtualizarRegistro(
        RequisicaoSaida registroEditado)
    {
        Data = registroEditado.Data;
        PacienteId = registroEditado.PacienteId;
        MedicamentoId = registroEditado.MedicamentoId;
        Quantidade = registroEditado.Quantidade;
    }
}