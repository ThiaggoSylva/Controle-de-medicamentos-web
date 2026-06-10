using FluentResults;

using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.DTOs;

namespace ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.Servicos;

public interface IServicoMedicamento
{
    Result Cadastrar(
        CadastrarMedicamentoDto dto);

    Result Editar(
        EditarMedicamentoDto dto);

    Result Excluir(Guid id);

    MedicamentoDto? SelecionarPorId(Guid id);

    List<MedicamentoDto> SelecionarTodos();
}