using ControleMedicamentosWeb.ModuloFornecedor.Dominio;
using ControleMedicamentosWeb.ModuloPaciente.Dominio;
using ControleMedicamentosWeb.ModuloMedicamento.Dominio;

namespace ControleMedicamentosWeb.Compartilhado;

public class DadosAplicacao
{
    public List<Fornecedor> Fornecedores { get; set; } = [];
    public List<Paciente> Pacientes { get; set; } = [];

    public List<Medicamento> Medicamentos { get; set; } = [];
}