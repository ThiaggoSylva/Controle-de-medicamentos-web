using ControleMedicamentosWeb.Compartilhado;

namespace ControleMedicamentosWeb.ModuloRequisicaoEntrada.Dominio;

public class RequisicaoEntrada
    : EntidadeBase<RequisicaoEntrada>
{
    public DateTime Data { get; set; }

    public Guid MedicamentoId { get; set; }

    public Guid FuncionarioId { get; set; }

    public int Quantidade { get; set; }

    public override void AtualizarRegistro(
        RequisicaoEntrada registroEditado)
    {
        Data = registroEditado.Data;
        MedicamentoId = registroEditado.MedicamentoId;
        FuncionarioId = registroEditado.FuncionarioId;
        Quantidade = registroEditado.Quantidade;
    }
}