using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.Servicos;

using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.DTOs;

using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloRequisicaoEntrada.Apresentacao.Controllers;

public class RequisicaoEntradaController : Controller
{
    private readonly IServicoRequisicaoEntrada servicoEntrada;

    private readonly IServicoMedicamento servicoMedicamento;

    private readonly IServicoFuncionario servicoFuncionario;

    private readonly IMapper mapper;

    public RequisicaoEntradaController(
        IServicoRequisicaoEntrada servicoEntrada,
        IServicoMedicamento servicoMedicamento,
        IServicoFuncionario servicoFuncionario,
        IMapper mapper)
    {
        this.servicoEntrada = servicoEntrada;
        this.servicoMedicamento = servicoMedicamento;
        this.servicoFuncionario = servicoFuncionario;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<RequisicaoEntradaDto> registros =
            servicoEntrada.SelecionarTodos();

        List<VisualizarRequisicaoEntradaViewModel> viewModels =
            mapper.Map<List<VisualizarRequisicaoEntradaViewModel>>(
                registros);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        CadastrarRequisicaoEntradaViewModel viewModel =
            new();

        CarregarMedicamentos(viewModel);

        CarregarFuncionarios(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarRequisicaoEntradaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarMedicamentos(viewModel);
            CarregarFuncionarios(viewModel);

            return View(viewModel);
        }

        CadastrarRequisicaoEntradaDto dto =
            mapper.Map<CadastrarRequisicaoEntradaDto>(
                viewModel);

        Result resultado =
            servicoEntrada.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);
            }

            CarregarMedicamentos(viewModel);
            CarregarFuncionarios(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Requisição registrada com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    private void CarregarMedicamentos(
        CadastrarRequisicaoEntradaViewModel viewModel)
    {
        List<MedicamentoDto> medicamentos =
            servicoMedicamento.SelecionarTodos();

        viewModel.Medicamentos =
            medicamentos
                .Select(m => new SelectListItem(
                    m.Nome,
                    m.Id.ToString()))
                .ToList();
    }

    private void CarregarFuncionarios(
        CadastrarRequisicaoEntradaViewModel viewModel)
    {
        List<FuncionarioDto> funcionarios =
            servicoFuncionario.SelecionarTodos();

        viewModel.Funcionarios =
            funcionarios
                .Select(f => new SelectListItem(
                    f.Nome,
                    f.Id.ToString()))
                .ToList();
    }
}