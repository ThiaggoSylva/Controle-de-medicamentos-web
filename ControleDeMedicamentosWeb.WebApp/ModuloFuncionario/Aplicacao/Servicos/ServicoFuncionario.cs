using AutoMapper;

using FluentResults;

using ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloFuncionario.Dominio;

namespace ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.Servicos;

public class ServicoFuncionario
    : IServicoFuncionario
{
    private readonly IRepositorioFuncionario repositorioFuncionario;

    private readonly IMapper mapper;

    public ServicoFuncionario(
        IRepositorioFuncionario repositorioFuncionario,
        IMapper mapper)
    {
        this.repositorioFuncionario =
            repositorioFuncionario;

        this.mapper = mapper;
    }

    public Result Cadastrar(
        CadastrarFuncionarioDto dto)
    {
        Result resultado =
            Validar(dto);

        if (resultado.IsFailed)
            return resultado;

        if (repositorioFuncionario.ExisteCPF(dto.CPF))
        {
            return Result.Fail(
                "Já existe um funcionário cadastrado com este CPF.");
        }

        Funcionario funcionario =
            mapper.Map<Funcionario>(dto);

        repositorioFuncionario.Cadastrar(
            funcionario);

        return Result.Ok();
    }

    public Result Editar(
        EditarFuncionarioDto dto)
    {
        Result resultado =
            Validar(dto);

        if (resultado.IsFailed)
            return resultado;

        Funcionario? funcionarioExistente =
            repositorioFuncionario
                .SelecionarPorCPF(dto.CPF);

        if (funcionarioExistente is not null
            && funcionarioExistente.Id != dto.Id)
        {
            return Result.Fail(
                "Já existe um funcionário cadastrado com este CPF.");
        }

        Funcionario funcionario =
            mapper.Map<Funcionario>(dto);

        repositorioFuncionario.Editar(
            funcionario);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Funcionario? funcionario =
            repositorioFuncionario
                .SelecionarPorId(id);

        if (funcionario is null)
        {
            return Result.Fail(
                "Funcionário não encontrado.");
        }

        repositorioFuncionario.Excluir(
            funcionario);

        return Result.Ok();
    }

    public FuncionarioDto? SelecionarPorId(
        Guid id)
    {
        Funcionario? funcionario =
            repositorioFuncionario
                .SelecionarPorId(id);

        if (funcionario is null)
            return null;

        return mapper.Map<FuncionarioDto>(
            funcionario);
    }

    public List<FuncionarioDto> SelecionarTodos()
    {
        List<Funcionario> funcionarios =
            repositorioFuncionario
                .SelecionarTodos();

        return mapper.Map<List<FuncionarioDto>>(
            funcionarios);
    }

    private Result Validar(
        CadastrarFuncionarioDto dto)
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

        if (string.IsNullOrWhiteSpace(dto.Telefone))
            resultado.WithError(
                "O telefone é obrigatório.");

        if (!string.IsNullOrWhiteSpace(dto.Telefone)
            && !System.Text.RegularExpressions.Regex.IsMatch(
                dto.Telefone,
                @"^\(\d{2}\)\s\d{4,5}-\d{4}$"))
        {
            resultado.WithError(
                "Telefone inválido.");
        }

        if (string.IsNullOrWhiteSpace(dto.CPF))
            resultado.WithError(
                "O CPF é obrigatório.");

        if (!string.IsNullOrWhiteSpace(dto.CPF)
            && dto.CPF.Length != 11)
        {
            resultado.WithError(
                "O CPF deve possuir 11 dígitos.");
        }

        return resultado;
    }

    private Result Validar(
        EditarFuncionarioDto dto)
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

        if (string.IsNullOrWhiteSpace(dto.Telefone))
            resultado.WithError(
                "O telefone é obrigatório.");

        if (!string.IsNullOrWhiteSpace(dto.Telefone)
            && !System.Text.RegularExpressions.Regex.IsMatch(
                dto.Telefone,
                @"^\(\d{2}\)\s\d{4,5}-\d{4}$"))
        {
            resultado.WithError(
                "Telefone inválido.");
        }

        if (string.IsNullOrWhiteSpace(dto.CPF))
            resultado.WithError(
                "O CPF é obrigatório.");

        if (!string.IsNullOrWhiteSpace(dto.CPF)
            && dto.CPF.Length != 11)
        {
            resultado.WithError(
                "O CPF deve possuir 11 dígitos.");
        }

        return resultado;
    }
}