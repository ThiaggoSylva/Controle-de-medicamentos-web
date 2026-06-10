using System.ComponentModel.DataAnnotations;

namespace ControleMedicamentosWeb.ModuloFuncionario.Apresentacao.Models;

public class EditarFuncionarioViewModel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3, ErrorMessage = "O nome deve possuir no mínimo 3 caracteres.")]
    [MaxLength(100, ErrorMessage = "O nome deve possuir no máximo 100 caracteres.")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [RegularExpression(
        @"^\(\d{2}\)\s\d{4,5}-\d{4}$",
        ErrorMessage = "Telefone inválido.")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [StringLength(
        11,
        MinimumLength = 11,
        ErrorMessage = "O CPF deve possuir 11 dígitos.")]
    public string CPF { get; set; } = string.Empty;
}