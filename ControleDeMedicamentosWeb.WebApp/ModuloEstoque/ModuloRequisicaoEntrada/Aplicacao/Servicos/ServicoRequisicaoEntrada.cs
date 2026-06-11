using AutoMapper;

using FluentResults;

using ControleMedicamentosWeb.ModuloMedicamento.Dominio;
using ControleMedicamentosWeb.ModuloFuncionario.Dominio;

using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Dominio;
using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.Servicos;

public class ServicoRequisicaoEntrada
    : IServicoRequisicaoEntrada
{
    private readonly IRepositorioRequisicaoEntrada repositorioEntrada;

    private readonly IRepositorioMedicamento repositorioMedicamento;

    private readonly IRepositorioFuncionario repositorioFuncionario;

    private readonly IMapper mapper;

    public ServicoRequisicaoEntrada(
        IRepositorioRequisicaoEntrada repositorioEntrada,
        IRepositorioMedicamento repositorioMedicamento,
        IRepositorioFuncionario repositorioFuncionario,
        IMapper mapper)
    {
        this.repositorioEntrada = repositorioEntrada;
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFuncionario = repositorioFuncionario;
        this.mapper = mapper;
    }

    public Result Cadastrar(
        CadastrarRequisicaoEntradaDto dto)
    {
        Result resultado = Validar(dto);

        if (resultado.IsFailed)
            return resultado;

        Medicamento? medicamento =
            repositorioMedicamento
                .SelecionarPorId(dto.MedicamentoId);

        if (medicamento is null)
            return Result.Fail(
                "Medicamento não encontrado.");

        Funcionario? funcionario =
            repositorioFuncionario
                .SelecionarPorId(dto.FuncionarioId);

        if (funcionario is null)
            return Result.Fail(
                "Funcionário não encontrado.");

        RequisicaoEntrada requisicao =
            mapper.Map<RequisicaoEntrada>(dto);

        repositorioEntrada.Cadastrar(requisicao);

        medicamento.QuantidadeEstoque += dto.Quantidade;

        repositorioMedicamento.Editar(medicamento);

        return Result.Ok();
    }

    public List<RequisicaoEntradaDto> SelecionarTodos()
    {
        List<RequisicaoEntrada> registros =
            repositorioEntrada.SelecionarTodos();

        List<RequisicaoEntradaDto> resultado = [];

        foreach (var entrada in registros)
        {
            Medicamento? medicamento =
                repositorioMedicamento
                    .SelecionarPorId(entrada.MedicamentoId);

            Funcionario? funcionario =
                repositorioFuncionario
                    .SelecionarPorId(entrada.FuncionarioId);

            resultado.Add(
                new RequisicaoEntradaDto(
                    entrada.Id,
                    entrada.Data,
                    entrada.MedicamentoId,
                    entrada.FuncionarioId,
                    entrada.Quantidade,
                    medicamento?.Nome ?? "",
                    funcionario?.Nome ?? ""
                ));
        }

        return resultado;
    }

    private Result Validar(
        CadastrarRequisicaoEntradaDto dto)
    {
        Result resultado = new();

        if (dto.Data == DateTime.MinValue)
        {
            resultado.WithError(
                "A data é obrigatória.");
        }

        if (dto.MedicamentoId == Guid.Empty)
        {
            resultado.WithError(
                "Selecione um medicamento.");
        }

        if (dto.FuncionarioId == Guid.Empty)
        {
            resultado.WithError(
                "Selecione um funcionário.");
        }

        if (dto.Quantidade <= 0)
        {
            resultado.WithError(
                "A quantidade deve ser maior que zero.");
        }

        return resultado;
    }
}