using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;

using ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloFuncionario.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloFuncionario.Apresentacao.Controllers;

public class FuncionarioController : Controller
{
    private readonly IServicoFuncionario servicoFuncionario;

    private readonly IMapper mapper;

    public FuncionarioController(
        IServicoFuncionario servicoFuncionario,
        IMapper mapper)
    {
        this.servicoFuncionario = servicoFuncionario;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<FuncionarioDto> registros =
            servicoFuncionario.SelecionarTodos();

        List<VisualizarFuncionarioViewModel> viewModels =
            mapper.Map<List<VisualizarFuncionarioViewModel>>(
                registros);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        CadastrarFuncionarioViewModel viewModel =
            new();

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarFuncionarioViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        CadastrarFuncionarioDto dto =
            mapper.Map<CadastrarFuncionarioDto>(
                viewModel);

        Result resultado =
            servicoFuncionario.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);
            }

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Funcionário cadastrado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        FuncionarioDto? funcionario =
            servicoFuncionario.SelecionarPorId(id);

        if (funcionario is null)
            return RedirectToAction(nameof(Index));

        EditarFuncionarioViewModel viewModel =
            mapper.Map<EditarFuncionarioViewModel>(
                funcionario);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(
        EditarFuncionarioViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        EditarFuncionarioDto dto =
            mapper.Map<EditarFuncionarioDto>(
                viewModel);

        Result resultado =
            servicoFuncionario.Editar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);
            }

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Funcionário editado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        FuncionarioDto? funcionario =
            servicoFuncionario.SelecionarPorId(id);

        if (funcionario is null)
            return RedirectToAction(nameof(Index));

        VisualizarFuncionarioViewModel viewModel =
            mapper.Map<VisualizarFuncionarioViewModel>(
                funcionario);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        Result resultado =
            servicoFuncionario.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] =
                resultado.Errors.First().Message;
        }
        else
        {
            TempData["Sucesso"] =
                "Funcionário excluído com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }
}