using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloMedicamento.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloMedicamento.Apresentacao.Controllers;

public class MedicamentoController : Controller
{
    private readonly IServicoMedicamento servicoMedicamento;

    private readonly IServicoFornecedor servicoFornecedor;

    private readonly IMapper mapper;

    public MedicamentoController(
        IServicoMedicamento servicoMedicamento,
        IServicoFornecedor servicoFornecedor,
        IMapper mapper)
    {
        this.servicoMedicamento = servicoMedicamento;
        this.servicoFornecedor = servicoFornecedor;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<MedicamentoDto> registros =
            servicoMedicamento.SelecionarTodos();

        List<VisualizarMedicamentoViewModel> viewModels =
            mapper.Map<List<VisualizarMedicamentoViewModel>>(
                registros);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        CadastrarMedicamentoViewModel viewModel = new();

        CarregarFornecedores(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarMedicamentoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarFornecedores(viewModel);

            return View(viewModel);
        }

        CadastrarMedicamentoDto dto =
            mapper.Map<CadastrarMedicamentoDto>(
                viewModel);

        Result resultado =
            servicoMedicamento.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);
            }

            CarregarFornecedores(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Medicamento cadastrado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        MedicamentoDto? medicamento =
            servicoMedicamento.SelecionarPorId(id);

        if (medicamento is null)
            return RedirectToAction(nameof(Index));

        EditarMedicamentoViewModel viewModel =
            mapper.Map<EditarMedicamentoViewModel>(
                medicamento);

        CarregarFornecedores(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(
        EditarMedicamentoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarFornecedores(viewModel);

            return View(viewModel);
        }

        EditarMedicamentoDto dto =
            mapper.Map<EditarMedicamentoDto>(
                viewModel);

        Result resultado =
            servicoMedicamento.Editar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);
            }

            CarregarFornecedores(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Medicamento editado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        MedicamentoDto? medicamento =
            servicoMedicamento.SelecionarPorId(id);

        if (medicamento is null)
            return RedirectToAction(nameof(Index));

        VisualizarMedicamentoViewModel viewModel =
            mapper.Map<VisualizarMedicamentoViewModel>(
                medicamento);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        Result resultado =
            servicoMedicamento.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] =
                resultado.Errors.First().Message;
        }
        else
        {
            TempData["Sucesso"] =
                "Medicamento excluído com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }

    private void CarregarFornecedores(
        CadastrarMedicamentoViewModel viewModel)
    {
        viewModel.Fornecedores =
            servicoFornecedor
                .SelecionarTodos()
                .Select(f => new SelectListItem(
                    f.Nome,
                    f.Id.ToString()))
                .ToList();
    }

    private void CarregarFornecedores(
        EditarMedicamentoViewModel viewModel)
    {
        viewModel.Fornecedores =
            servicoFornecedor
                .SelecionarTodos()
                .Select(f => new SelectListItem(
                    f.Nome,
                    f.Id.ToString()))
                .ToList();
    }
}