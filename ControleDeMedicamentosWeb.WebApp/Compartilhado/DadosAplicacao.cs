using ControleMedicamentosWeb.ModuloFornecedor.Dominio;
using ControleMedicamentosWeb.ModuloPaciente.Dominio;
using ControleMedicamentosWeb.ModuloMedicamento.Dominio;
using ControleMedicamentosWeb.ModuloFuncionario.Dominio;
using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Dominio;
using ControleMedicamentosWeb.ModuloRequisicaoSaida.Dominio;

namespace ControleMedicamentosWeb.Compartilhado;

public class DadosAplicacao
{
    public List<Fornecedor> Fornecedores { get; set; } = [];
    public List<Paciente> Pacientes { get; set; } = [];

    public List<Medicamento> Medicamentos { get; set; } = [];

    public List<Funcionario> Funcionarios { get; set; } = [];

    public List<RequisicaoEntrada> RequisicoesEntrada { get; set; } = [];

    public List<RequisicaoSaida> RequisicoesSaida { get; set; } = [];
}