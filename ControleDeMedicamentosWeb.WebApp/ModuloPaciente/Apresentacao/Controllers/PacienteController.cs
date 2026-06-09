using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;

using ControleMedicamentosWeb.ModuloPaciente.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloPaciente.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloPaciente.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloPaciente.Apresentacao.Controllers;

public class PacienteController : Controller
{
    private readonly IServicoPaciente servicoPaciente;

    private readonly IMapper mapper;

    public PacienteController(
        IServicoPaciente servicoPaciente,
        IMapper mapper)
    {
        this.servicoPaciente = servicoPaciente;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<PacienteDto> pacientes =
            servicoPaciente.SelecionarTodos();

        List<VisualizarPacienteViewModel> viewModels =
            mapper.Map<List<VisualizarPacienteViewModel>>(
                pacientes);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        ViewBag.Titulo = "Cadastrar Paciente";

        return View(
            new CadastrarPacienteViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarPacienteViewModel viewModel)
    {
        ViewBag.Titulo = "Cadastrar Paciente";

        if (!ModelState.IsValid)
            return View(viewModel);

        CadastrarPacienteDto dto =
            mapper.Map<CadastrarPacienteDto>(
                viewModel);

        Result resultado =
            servicoPaciente.Cadastrar(dto);

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
            "Paciente cadastrado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        ViewBag.Titulo = "Editar Paciente";

        PacienteDto? paciente =
            servicoPaciente.SelecionarPorId(id);

        if (paciente is null)
        {
            TempData["Erro"] =
                "Paciente não encontrado.";

            return RedirectToAction(nameof(Index));
        }

        EditarPacienteViewModel viewModel =
            mapper.Map<EditarPacienteViewModel>(
                paciente);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(
        EditarPacienteViewModel viewModel)
    {
        ViewBag.Titulo = "Editar Paciente";

        if (!ModelState.IsValid)
            return View(viewModel);

        EditarPacienteDto dto =
            mapper.Map<EditarPacienteDto>(
                viewModel);

        Result resultado =
            servicoPaciente.Editar(dto);

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
            "Paciente editado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        ViewBag.Titulo = "Excluir Paciente";

        PacienteDto? paciente =
            servicoPaciente.SelecionarPorId(id);

        if (paciente is null)
        {
            TempData["Erro"] =
                "Paciente não encontrado.";

            return RedirectToAction(nameof(Index));
        }

        VisualizarPacienteViewModel viewModel =
            mapper.Map<VisualizarPacienteViewModel>(
                paciente);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        Result resultado =
            servicoPaciente.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] =
                resultado.Errors.First().Message;
        }
        else
        {
            TempData["Sucesso"] =
                "Paciente excluído com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }
}