using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Apresentacao.Models;

public class CadastrarRequisicaoSaidaViewModel
{
    [Required(ErrorMessage = "A data é obrigatória.")]
    public DateTime Data { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Selecione um paciente.")]
    public Guid PacienteId { get; set; }

    [Required(ErrorMessage = "Selecione um medicamento.")]
    public Guid MedicamentoId { get; set; }

    [Range(
        1,
        int.MaxValue,
        ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int Quantidade { get; set; }

    public List<SelectListItem> Pacientes { get; set; } = [];

    public List<SelectListItem> Medicamentos { get; set; } = [];
}