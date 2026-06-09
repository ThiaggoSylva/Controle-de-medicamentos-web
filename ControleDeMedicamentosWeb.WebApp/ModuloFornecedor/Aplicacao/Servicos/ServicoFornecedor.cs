using AutoMapper;

using FluentResults;

using ControleMedicamentosWeb.ModuloFornecedor.Dominio;
using ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.Servicos;

public class ServicoFornecedor
    : IServicoFornecedor
{
    private readonly IRepositorioFornecedor repositorioFornecedor;

    private readonly IMapper mapper;

    public ServicoFornecedor(
        IRepositorioFornecedor repositorioFornecedor,
        IMapper mapper)
    {
        this.repositorioFornecedor =
            repositorioFornecedor;

        this.mapper = mapper;
    }

    public Result Cadastrar(
        CadastrarFornecedorDto dto)
    {
        Result resultadoValidacao =
            ValidarCadastro(dto);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        Fornecedor fornecedor =
            mapper.Map<Fornecedor>(dto);

        repositorioFornecedor.Cadastrar(
            fornecedor);

        return Result.Ok();
    }

    public Result Editar(
        EditarFornecedorDto dto)
    {
        Result resultadoValidacao =
            ValidarEdicao(dto);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        Fornecedor fornecedor =
            mapper.Map<Fornecedor>(dto);

        repositorioFornecedor.Editar(
            fornecedor);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Fornecedor? fornecedor =
            repositorioFornecedor
                .SelecionarPorId(id);

        if (fornecedor is null)
            return Result.Fail(
                "Fornecedor não encontrado.");

        repositorioFornecedor.Excluir(
            fornecedor);

        return Result.Ok();
    }

    public FornecedorDto? SelecionarPorId(
        Guid id)
    {
        Fornecedor? fornecedor =
            repositorioFornecedor
                .SelecionarPorId(id);

        if (fornecedor is null)
            return null;

        return mapper.Map<FornecedorDto>(
            fornecedor);
    }

    public List<FornecedorDto> SelecionarTodos()
    {
        List<Fornecedor> fornecedores =
            repositorioFornecedor
                .SelecionarTodos();

        return mapper.Map<
            List<FornecedorDto>>(
            fornecedores);
    }

    private Result ValidarCadastro(
        CadastrarFornecedorDto dto)
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

        string telefone =
            dto.Telefone?
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .Replace(" ", "")
            ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(telefone)
            && telefone.Length is not 10 and not 11)
        {
            resultado.WithError(
                "Telefone inválido.");
        }

        if (!telefone.All(char.IsDigit)
            && telefone.Length > 0)
        {
            resultado.WithError(
                "Telefone inválido.");
        }

        if (string.IsNullOrWhiteSpace(dto.Cnpj))
            resultado.WithError(
                "O CNPJ é obrigatório.");

        string cnpj =
            dto.Cnpj?
                .Replace(".", "")
                .Replace("/", "")
                .Replace("-", "")
            ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(cnpj)
            && cnpj.Length != 14)
        {
            resultado.WithError(
                "O CNPJ deve possuir 14 dígitos.");
        }

        if (!cnpj.All(char.IsDigit)
            && cnpj.Length > 0)
        {
            resultado.WithError(
                "CNPJ inválido.");
        }

        if (repositorioFornecedor
            .ExisteCnpj(cnpj))
        {
            resultado.WithError(
                "Já existe um fornecedor cadastrado com este CNPJ.");
        }

        return resultado;
    }

    private Result ValidarEdicao(
        EditarFornecedorDto dto)
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

        string telefone =
            dto.Telefone?
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "")
                .Replace(" ", "")
            ?? string.Empty;

        if (!string.IsNullOrWhiteSpace(telefone)
            && telefone.Length is not 10 and not 11)
        {
            resultado.WithError(
                "Telefone inválido.");
        }

        if (!telefone.All(char.IsDigit)
            && telefone.Length > 0)
        {
            resultado.WithError(
                "Telefone inválido.");
        }

        string cnpj =
            dto.Cnpj?
                .Replace(".", "")
                .Replace("/", "")
                .Replace("-", "")
            ?? string.Empty;

        if (string.IsNullOrWhiteSpace(cnpj))
            resultado.WithError(
                "O CNPJ é obrigatório.");

        if (!string.IsNullOrWhiteSpace(cnpj)
            && cnpj.Length != 14)
        {
            resultado.WithError(
                "O CNPJ deve possuir 14 dígitos.");
        }

        if (!cnpj.All(char.IsDigit)
            && cnpj.Length > 0)
        {
            resultado.WithError(
                "CNPJ inválido.");
        }

        if (repositorioFornecedor
            .ExisteCnpj(dto.Id, cnpj))
        {
            resultado.WithError(
                "Já existe um fornecedor cadastrado com este CNPJ.");
        }

        return resultado;
    }
}