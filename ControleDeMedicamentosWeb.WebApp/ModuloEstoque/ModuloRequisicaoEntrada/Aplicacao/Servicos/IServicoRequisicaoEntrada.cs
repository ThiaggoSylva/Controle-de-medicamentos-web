using FluentResults;

using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.Servicos;

public interface IServicoRequisicaoEntrada
{
    Result Cadastrar(
        CadastrarRequisicaoEntradaDto dto);

    List<RequisicaoEntradaDto> SelecionarTodos();
}