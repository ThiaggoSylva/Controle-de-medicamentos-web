using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;

using ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloFornecedor.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloFornecedor.Apresentacao.Controllers;

public class FornecedorController : Controller
{
    private readonly IServicoFornecedor servicoFornecedor;

    private readonly IMapper mapper;

    public FornecedorController(
        IServicoFornecedor servicoFornecedor,
        IMapper mapper)
    {
        this.servicoFornecedor = servicoFornecedor;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<FornecedorDto> fornecedores =
            servicoFornecedor.SelecionarTodos();

        List<VisualizarFornecedorViewModel> viewModels =
            mapper.Map<List<VisualizarFornecedorViewModel>>(
                fornecedores);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        ViewBag.Titulo = "Cadastrar Fornecedor";

        return View(new CadastrarFornecedorViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarFornecedorViewModel viewModel)
    {
        ViewBag.Titulo = "Cadastrar Fornecedor";

        if (!ModelState.IsValid)
            return View(viewModel);

        CadastrarFornecedorDto dto =
            mapper.Map<CadastrarFornecedorDto>(
                viewModel);

        Result resultado =
            servicoFornecedor.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Fornecedor cadastrado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        ViewBag.Titulo = "Editar Fornecedor";

        FornecedorDto? fornecedor =
            servicoFornecedor.SelecionarPorId(id);

        if (fornecedor is null)
        {
            TempData["Erro"] =
                "Fornecedor não encontrado.";

            return RedirectToAction(nameof(Index));
        }

        EditarFornecedorViewModel viewModel =
            mapper.Map<EditarFornecedorViewModel>(
                fornecedor);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(
        EditarFornecedorViewModel viewModel)
    {
        ViewBag.Titulo = "Editar Fornecedor";

        if (!ModelState.IsValid)
            return View(viewModel);

        EditarFornecedorDto dto =
            mapper.Map<EditarFornecedorDto>(
                viewModel);

        Result resultado =
            servicoFornecedor.Editar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Fornecedor editado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        ViewBag.Titulo = "Excluir Fornecedor";

        FornecedorDto? fornecedor =
            servicoFornecedor.SelecionarPorId(id);

        if (fornecedor is null)
        {
            TempData["Erro"] =
                "Fornecedor não encontrado.";

            return RedirectToAction(nameof(Index));
        }

        VisualizarFornecedorViewModel viewModel =
            mapper.Map<VisualizarFornecedorViewModel>(
                fornecedor);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        Result resultado =
            servicoFornecedor.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] =
                resultado.Errors.First().Message;
        }
        else
        {
            TempData["Sucesso"] =
                "Fornecedor excluído com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }
}