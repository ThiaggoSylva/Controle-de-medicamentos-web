using System.ComponentModel.DataAnnotations;

namespace ControleMedicamentosWeb.ModuloFornecedor.Apresentacao.Models;

public class EditarFornecedorViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3,
        ErrorMessage = "O nome deve possuir no mínimo 3 caracteres.")]
    [MaxLength(100,
        ErrorMessage = "O nome deve possuir no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CNPJ é obrigatório.")]
    public string Cnpj { get; set; } = string.Empty;
}