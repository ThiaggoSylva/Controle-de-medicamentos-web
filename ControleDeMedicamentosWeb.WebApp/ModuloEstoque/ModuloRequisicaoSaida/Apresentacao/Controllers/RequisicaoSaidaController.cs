using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ControleMedicamentosWeb.ModuloPaciente.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloPaciente.Aplicacao.Servicos;

using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.Servicos;

using ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloRequisicaoSaida.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Apresentacao.Controllers;

public class RequisicaoSaidaController : Controller
{
    private readonly IServicoRequisicaoSaida servicoSaida;

    private readonly IServicoPaciente servicoPaciente;

    private readonly IServicoMedicamento servicoMedicamento;

    private readonly IMapper mapper;

    public RequisicaoSaidaController(
        IServicoRequisicaoSaida servicoSaida,
        IServicoPaciente servicoPaciente,
        IServicoMedicamento servicoMedicamento,
        IMapper mapper)
    {
        this.servicoSaida = servicoSaida;
        this.servicoPaciente = servicoPaciente;
        this.servicoMedicamento = servicoMedicamento;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<RequisicaoSaidaDto> registros =
            servicoSaida.SelecionarTodos();

        List<VisualizarRequisicaoSaidaViewModel> viewModels =
            mapper.Map<List<VisualizarRequisicaoSaidaViewModel>>(registros);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        CadastrarRequisicaoSaidaViewModel viewModel = new();

        CarregarPacientes(viewModel);

        CarregarMedicamentos(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarRequisicaoSaidaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarPacientes(viewModel);
            CarregarMedicamentos(viewModel);

            return View(viewModel);
        }

        CadastrarRequisicaoSaidaDto dto =
            mapper.Map<CadastrarRequisicaoSaidaDto>(viewModel);

        Result resultado =
            servicoSaida.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            CarregarPacientes(viewModel);
            CarregarMedicamentos(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Requisição de saída registrada com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    private void CarregarPacientes(
        CadastrarRequisicaoSaidaViewModel viewModel)
    {
        List<PacienteDto> pacientes =
            servicoPaciente.SelecionarTodos();

        viewModel.Pacientes =
            pacientes
                .Select(p =>
                    new SelectListItem(
                        p.Nome,
                        p.Id.ToString()))
                .ToList();
    }

    private void CarregarMedicamentos(
        CadastrarRequisicaoSaidaViewModel viewModel)
    {
        List<MedicamentoDto> medicamentos =
            servicoMedicamento.SelecionarTodos();

        viewModel.Medicamentos =
            medicamentos
                .Select(m =>
                    new SelectListItem(
                        m.Nome,
                        m.Id.ToString()))
                .ToList();
    }
}