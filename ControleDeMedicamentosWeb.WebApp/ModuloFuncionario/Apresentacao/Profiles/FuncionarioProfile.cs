using AutoMapper;

using ControleMedicamentosWeb.ModuloFuncionario.Dominio;
using ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloFuncionario.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloFuncionario.Apresentacao.Profiles;

public class FuncionarioProfile : Profile
{
    public FuncionarioProfile()
    {
        CreateMap<CadastrarFuncionarioViewModel,
                  CadastrarFuncionarioDto>();

        CreateMap<EditarFuncionarioViewModel,
                  EditarFuncionarioDto>();


        CreateMap<CadastrarFuncionarioDto,
                  Funcionario>();

        CreateMap<EditarFuncionarioDto,
                  Funcionario>();


        CreateMap<Funcionario,
                  FuncionarioDto>()
            .ForCtorParam(
                nameof(FuncionarioDto.Id),
                opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(
                nameof(FuncionarioDto.Nome),
                opt => opt.MapFrom(src => src.Nome))
            .ForCtorParam(
                nameof(FuncionarioDto.Telefone),
                opt => opt.MapFrom(src => src.Telefone))
            .ForCtorParam(
                nameof(FuncionarioDto.CPF),
                opt => opt.MapFrom(src => src.CPF));


        CreateMap<FuncionarioDto,
                  VisualizarFuncionarioViewModel>();


        CreateMap<FuncionarioDto,
                  EditarFuncionarioViewModel>();
    }
}