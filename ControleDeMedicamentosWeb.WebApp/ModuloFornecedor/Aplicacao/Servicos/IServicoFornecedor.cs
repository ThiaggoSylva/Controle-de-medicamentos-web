using FluentResults;

using ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.Servicos;

public interface IServicoFornecedor
{
    Result Cadastrar(
        CadastrarFornecedorDto dto);

    Result Editar(
        EditarFornecedorDto dto);

    Result Excluir(Guid id);

    FornecedorDto? SelecionarPorId(Guid id);

    List<FornecedorDto> SelecionarTodos();
}