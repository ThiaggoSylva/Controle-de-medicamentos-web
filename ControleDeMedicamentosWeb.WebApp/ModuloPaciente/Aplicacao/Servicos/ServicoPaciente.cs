using AutoMapper;

using FluentResults;

using ControleMedicamentosWeb.ModuloPaciente.Dominio;
using ControleMedicamentosWeb.ModuloPaciente.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloPaciente.Aplicacao.Servicos;

public class ServicoPaciente
    : IServicoPaciente
{
    private readonly IRepositorioPaciente repositorioPaciente;

    private readonly IMapper mapper;

    public ServicoPaciente(
        IRepositorioPaciente repositorioPaciente,
        IMapper mapper)
    {
        this.repositorioPaciente =
            repositorioPaciente;

        this.mapper = mapper;
    }

    public Result Cadastrar(
        CadastrarPacienteDto dto)
    {
        Result resultado =
            ValidarCadastro(dto);

        if (resultado.IsFailed)
            return resultado;

        Paciente paciente =
            mapper.Map<Paciente>(dto);

        repositorioPaciente.Cadastrar(
            paciente);

        return Result.Ok();
    }

    public Result Editar(
        EditarPacienteDto dto)
    {
        Result resultado =
            ValidarEdicao(dto);

        if (resultado.IsFailed)
            return resultado;

        Paciente paciente =
            mapper.Map<Paciente>(dto);

        repositorioPaciente.Editar(
            paciente);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Paciente? paciente =
            repositorioPaciente
                .SelecionarPorId(id);

        if (paciente is null)
            return Result.Fail(
                "Paciente não encontrado.");

        repositorioPaciente.Excluir(
            paciente);

        return Result.Ok();
    }

    public PacienteDto? SelecionarPorId(
        Guid id)
    {
        Paciente? paciente =
            repositorioPaciente
                .SelecionarPorId(id);

        if (paciente is null)
            return null;

        return mapper.Map<PacienteDto>(
            paciente);
    }

    public List<PacienteDto> SelecionarTodos()
    {
        List<Paciente> pacientes =
            repositorioPaciente
                .SelecionarTodos();

        return mapper.Map<List<PacienteDto>>(
            pacientes);
    }

    private Result ValidarCadastro(
        CadastrarPacienteDto dto)
    {
        Result resultado = new();

        if (string.IsNullOrWhiteSpace(dto.Nome))
            resultado.WithError(
                "O nome é obrigatório.");

        if (!string.IsNullOrWhiteSpace(dto.Nome)
            && (dto.Nome.Length < 3
            || dto.Nome.Length > 100))
        {
            resultado.WithError(
                "O nome deve possuir entre 3 e 100 caracteres.");
        }

        ValidarTelefone(
            dto.Telefone,
            resultado);

        ValidarCartaoSus(
            dto.CartaoSus,
            resultado);

        ValidarCpf(
            dto.Cpf,
            resultado);

        if (repositorioPaciente
            .ExisteCartaoSus(dto.CartaoSus))
        {
            resultado.WithError(
                "Já existe um paciente cadastrado com este Cartão SUS.");
        }

        return resultado;
    }

    private Result ValidarEdicao(
        EditarPacienteDto dto)
    {
        Result resultado = new();

        if (string.IsNullOrWhiteSpace(dto.Nome))
            resultado.WithError(
                "O nome é obrigatório.");

        if (!string.IsNullOrWhiteSpace(dto.Nome)
            && (dto.Nome.Length < 3
            || dto.Nome.Length > 100))
        {
            resultado.WithError(
                "O nome deve possuir entre 3 e 100 caracteres.");
        }

        ValidarTelefone(
            dto.Telefone,
            resultado);

        ValidarCartaoSus(
            dto.CartaoSus,
            resultado);

        ValidarCpf(
            dto.Cpf,
            resultado);

        if (repositorioPaciente
            .ExisteCartaoSus(
                dto.Id,
                dto.CartaoSus))
        {
            resultado.WithError(
                "Já existe um paciente cadastrado com este Cartão SUS.");
        }

        return resultado;
    }

    private static void ValidarTelefone(
        string telefone,
        Result resultado)
    {
        if (string.IsNullOrWhiteSpace(telefone))
        {
            resultado.WithError(
                "O telefone é obrigatório.");

            return;
        }

        string numero =
            telefone
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .Replace(" ", "");

        if (numero.Length is not 10 and not 11)
        {
            resultado.WithError(
                "Telefone inválido.");
        }

        if (!numero.All(char.IsDigit))
        {
            resultado.WithError(
                "Telefone inválido.");
        }
    }

    private static void ValidarCartaoSus(
        string cartaoSus,
        Result resultado)
    {
        if (string.IsNullOrWhiteSpace(cartaoSus))
        {
            resultado.WithError(
                "O Cartão SUS é obrigatório.");

            return;
        }

        if (cartaoSus.Length != 15)
        {
            resultado.WithError(
                "O Cartão SUS deve possuir 15 dígitos.");
        }

        if (!cartaoSus.All(char.IsDigit))
        {
            resultado.WithError(
                "Cartão SUS inválido.");
        }
    }

    private static void ValidarCpf(
        string cpf,
        Result resultado)
    {
        if (string.IsNullOrWhiteSpace(cpf))
        {
            resultado.WithError(
                "O CPF é obrigatório.");

            return;
        }

        string numero =
            cpf.Replace(".", "")
               .Replace("-", "");

        if (numero.Length != 11)
        {
            resultado.WithError(
                "O CPF deve possuir 11 dígitos.");
        }

        if (!numero.All(char.IsDigit))
        {
            resultado.WithError(
                "CPF inválido.");
        }
    }
}