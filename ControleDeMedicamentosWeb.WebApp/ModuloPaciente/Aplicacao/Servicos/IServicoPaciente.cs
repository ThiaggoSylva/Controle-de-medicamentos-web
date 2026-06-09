using FluentResults;

using ControleMedicamentosWeb.ModuloPaciente.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloPaciente.Aplicacao.Servicos;

public interface IServicoPaciente
{
    Result Cadastrar(
        CadastrarPacienteDto dto);

    Result Editar(
        EditarPacienteDto dto);

    Result Excluir(Guid id);

    PacienteDto? SelecionarPorId(Guid id);

    List<PacienteDto> SelecionarTodos();
}