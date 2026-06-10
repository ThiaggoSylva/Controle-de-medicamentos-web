using FluentResults;

using ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.Servicos;

public interface IServicoFuncionario
{
    Result Cadastrar(
        CadastrarFuncionarioDto dto);

    Result Editar(
        EditarFuncionarioDto dto);

    Result Excluir(Guid id);

    FuncionarioDto? SelecionarPorId(Guid id);

    List<FuncionarioDto> SelecionarTodos();
}