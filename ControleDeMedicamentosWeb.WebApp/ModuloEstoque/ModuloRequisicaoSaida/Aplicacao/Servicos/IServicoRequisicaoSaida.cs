using FluentResults;

using ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.Servicos;

public interface IServicoRequisicaoSaida
{
    Result Cadastrar(
        CadastrarRequisicaoSaidaDto dto);

    List<RequisicaoSaidaDto> SelecionarTodos();
}