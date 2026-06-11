using AutoMapper;

using FluentResults;

using ControleMedicamentosWeb.ModuloPaciente.Dominio;
using ControleMedicamentosWeb.ModuloMedicamento.Dominio;

using ControleMedicamentosWeb.ModuloRequisicaoSaida.Dominio;
using ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.Servicos;

public class ServicoRequisicaoSaida
    : IServicoRequisicaoSaida
{
    private readonly IRepositorioRequisicaoSaida repositorioSaida;

    private readonly IRepositorioPaciente repositorioPaciente;

    private readonly IRepositorioMedicamento repositorioMedicamento;

    private readonly IMapper mapper;

    public ServicoRequisicaoSaida(
        IRepositorioRequisicaoSaida repositorioSaida,
        IRepositorioPaciente repositorioPaciente,
        IRepositorioMedicamento repositorioMedicamento,
        IMapper mapper)
    {
        this.repositorioSaida = repositorioSaida;
        this.repositorioPaciente = repositorioPaciente;
        this.repositorioMedicamento = repositorioMedicamento;
        this.mapper = mapper;
    }

    public Result Cadastrar(
        CadastrarRequisicaoSaidaDto dto)
    {
        Result resultado = Validar(dto);

        if (resultado.IsFailed)
            return resultado;

        Paciente? paciente =
            repositorioPaciente
                .SelecionarPorId(dto.PacienteId);

        if (paciente is null)
            return Result.Fail(
                "Paciente não encontrado.");

        Medicamento? medicamento =
            repositorioMedicamento
                .SelecionarPorId(dto.MedicamentoId);

        if (medicamento is null)
            return Result.Fail(
                "Medicamento não encontrado.");

        if (medicamento.QuantidadeEstoque < dto.Quantidade)
        {
            return Result.Fail(
                "Estoque insuficiente para atender a requisição.");
        }

        RequisicaoSaida requisicao =
            mapper.Map<RequisicaoSaida>(dto);

        repositorioSaida.Cadastrar(requisicao);

        medicamento.QuantidadeEstoque -= dto.Quantidade;

        repositorioMedicamento.Editar(medicamento);

        return Result.Ok();
    }

    public List<RequisicaoSaidaDto> SelecionarTodos()
    {
        List<RequisicaoSaida> registros =
            repositorioSaida.SelecionarTodos();

        List<RequisicaoSaidaDto> resultado = [];

        foreach (var saida in registros)
        {
            Paciente? paciente =
                repositorioPaciente
                    .SelecionarPorId(saida.PacienteId);

            Medicamento? medicamento =
                repositorioMedicamento
                    .SelecionarPorId(saida.MedicamentoId);

            resultado.Add(
                new RequisicaoSaidaDto(
                    saida.Id,
                    saida.Data,
                    saida.PacienteId,
                    saida.MedicamentoId,
                    saida.Quantidade,
                    paciente?.Nome ?? "",
                    medicamento?.Nome ?? ""
                ));
        }

        return resultado;
    }

    private Result Validar(
        CadastrarRequisicaoSaidaDto dto)
    {
        Result resultado = new();

        if (dto.Data == DateTime.MinValue)
        {
            resultado.WithError(
                "A data é obrigatória.");
        }

        if (dto.PacienteId == Guid.Empty)
        {
            resultado.WithError(
                "Selecione um paciente.");
        }

        if (dto.MedicamentoId == Guid.Empty)
        {
            resultado.WithError(
                "Selecione um medicamento.");
        }

        if (dto.Quantidade <= 0)
        {
            resultado.WithError(
                "A quantidade deve ser maior que zero.");
        }

        return resultado;
    }
}