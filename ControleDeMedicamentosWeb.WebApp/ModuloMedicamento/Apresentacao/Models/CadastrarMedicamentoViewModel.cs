using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace ControleMedicamentosWeb.ModuloMedicamento.Apresentacao.Models;

public class CadastrarMedicamentoViewModel
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3)]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [MinLength(5)]
    [MaxLength(255)]
    public string Descricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    [Range(1, int.MaxValue,
        ErrorMessage = "A quantidade deve ser maior que zero.")]
    public int QuantidadeEstoque { get; set; }

    [Required(ErrorMessage = "Selecione um fornecedor.")]
    public Guid FornecedorId { get; set; }

    public List<SelectListItem> Fornecedores { get; set; } = [];
}