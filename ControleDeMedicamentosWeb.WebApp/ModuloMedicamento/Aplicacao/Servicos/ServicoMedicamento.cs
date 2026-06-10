using AutoMapper;

using FluentResults;

using ControleMedicamentosWeb.ModuloFornecedor.Dominio;
using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloMedicamento.Dominio;

namespace ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.Servicos;

public class ServicoMedicamento
    : IServicoMedicamento
{
    private readonly IRepositorioMedicamento repositorioMedicamento;

    private readonly IRepositorioFornecedor repositorioFornecedor;

    private readonly IMapper mapper;

    public ServicoMedicamento(
        IRepositorioMedicamento repositorioMedicamento,
        IRepositorioFornecedor repositorioFornecedor,
        IMapper mapper)
    {
        this.repositorioMedicamento =
            repositorioMedicamento;

        this.repositorioFornecedor =
            repositorioFornecedor;

        this.mapper = mapper;
    }

    public Result Cadastrar(
        CadastrarMedicamentoDto dto)
    {
        Result resultado =
            ValidarCadastro(dto);

        if (resultado.IsFailed)
            return resultado;

        Medicamento? medicamentoExistente =
            repositorioMedicamento
                .SelecionarPorNome(dto.Nome);

        if (medicamentoExistente is not null)
        {
            medicamentoExistente.QuantidadeEstoque +=
                dto.QuantidadeEstoque;

            repositorioMedicamento.Editar(
                medicamentoExistente);

            return Result.Ok();
        }

        Medicamento medicamento =
            mapper.Map<Medicamento>(dto);

        repositorioMedicamento.Cadastrar(
            medicamento);

        return Result.Ok();
    }

    public Result Editar(
        EditarMedicamentoDto dto)
    {
        Result resultado =
            ValidarEdicao(dto);

        if (resultado.IsFailed)
            return resultado;

        Medicamento medicamento =
            mapper.Map<Medicamento>(dto);

        repositorioMedicamento.Editar(
            medicamento);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Medicamento? medicamento =
            repositorioMedicamento
                .SelecionarPorId(id);

        if (medicamento is null)
            return Result.Fail(
                "Medicamento não encontrado.");

        repositorioMedicamento.Excluir(
            medicamento);

        return Result.Ok();
    }

    public MedicamentoDto? SelecionarPorId(
        Guid id)
    {
        Medicamento? medicamento =
            repositorioMedicamento
                .SelecionarPorId(id);

        if (medicamento is null)
            return null;

        Fornecedor? fornecedor =
            repositorioFornecedor
                .SelecionarPorId(
                    medicamento.FornecedorId);

        MedicamentoDto dto =
            mapper.Map<MedicamentoDto>(
                medicamento);

        dto = dto with
        {
            NomeFornecedor =
                fornecedor?.Nome ?? string.Empty
        };

        return dto;
    }

    public List<MedicamentoDto> SelecionarTodos()
    {
        List<Medicamento> medicamentos =
            repositorioMedicamento
                .SelecionarTodos();

        List<MedicamentoDto> dtos = [];

        foreach (Medicamento medicamento in medicamentos)
        {
            Fornecedor? fornecedor =
                repositorioFornecedor
                    .SelecionarPorId(
                        medicamento.FornecedorId);

            MedicamentoDto dto =
                mapper.Map<MedicamentoDto>(
                    medicamento);

            dto = dto with
            {
                NomeFornecedor =
                    fornecedor?.Nome ?? string.Empty
            };

            dtos.Add(dto);
        }

        return dtos;
    }

    private Result ValidarCadastro(
        CadastrarMedicamentoDto dto)
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

        if (string.IsNullOrWhiteSpace(dto.Descricao))
            resultado.WithError(
                "A descrição é obrigatória.");

        if (!string.IsNullOrWhiteSpace(dto.Descricao)
            && (dto.Descricao.Length < 5
            || dto.Descricao.Length > 255))
        {
            resultado.WithError(
                "A descrição deve possuir entre 5 e 255 caracteres.");
        }

        if (dto.QuantidadeEstoque <= 0)
            resultado.WithError(
                "A quantidade deve ser maior que zero.");

        if (dto.FornecedorId == Guid.Empty)
            resultado.WithError(
                "O fornecedor é obrigatório.");

        if (dto.FornecedorId != Guid.Empty)
        {
            Fornecedor? fornecedor =
                repositorioFornecedor
                    .SelecionarPorId(
                        dto.FornecedorId);

            if (fornecedor is null)
                resultado.WithError(
                    "Fornecedor não encontrado.");
        }

        return resultado;
    }

    private Result ValidarEdicao(
        EditarMedicamentoDto dto)
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

        if (string.IsNullOrWhiteSpace(dto.Descricao))
            resultado.WithError(
                "A descrição é obrigatória.");

        if (!string.IsNullOrWhiteSpace(dto.Descricao)
            && (dto.Descricao.Length < 5
            || dto.Descricao.Length > 255))
        {
            resultado.WithError(
                "A descrição deve possuir entre 5 e 255 caracteres.");
        }

        if (dto.QuantidadeEstoque <= 0)
            resultado.WithError(
                "A quantidade deve ser maior que zero.");

        if (dto.FornecedorId == Guid.Empty)
            resultado.WithError(
                "O fornecedor é obrigatório.");

        if (dto.FornecedorId != Guid.Empty)
        {
            Fornecedor? fornecedor =
                repositorioFornecedor
                    .SelecionarPorId(
                        dto.FornecedorId);

            if (fornecedor is null)
                resultado.WithError(
                    "Fornecedor não encontrado.");
        }

        return resultado;
    }
}