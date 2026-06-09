using AutoMapper;

using ControleMedicamentosWeb.ModuloPaciente.Dominio;
using ControleMedicamentosWeb.ModuloPaciente.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloPaciente.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloPaciente.Apresentacao.Profiles;

public class PacienteProfile : Profile
{
    public PacienteProfile()
    {
        // Entidade -> DTO

        CreateMap<Paciente, PacienteDto>();

        // DTO -> Entidade

        CreateMap<CadastrarPacienteDto, Paciente>();

        CreateMap<EditarPacienteDto, Paciente>();

        // ViewModel -> DTO

        CreateMap<CadastrarPacienteViewModel,
                  CadastrarPacienteDto>();

        CreateMap<EditarPacienteViewModel,
                  EditarPacienteDto>();

        // DTO -> ViewModel

        CreateMap<PacienteDto,
                  VisualizarPacienteViewModel>();

        CreateMap<PacienteDto,
                  EditarPacienteViewModel>();
    }
}