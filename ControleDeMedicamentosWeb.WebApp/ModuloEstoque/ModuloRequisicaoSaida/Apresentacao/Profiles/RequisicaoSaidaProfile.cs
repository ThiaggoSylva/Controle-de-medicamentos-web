using AutoMapper;

using ControleMedicamentosWeb.ModuloRequisicaoSaida.Dominio;
using ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloRequisicaoSaida.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloRequisicaoSaida.Apresentacao.Profiles;

public class RequisicaoSaidaProfile : Profile
{
    public RequisicaoSaidaProfile()
    {
        CreateMap<CadastrarRequisicaoSaidaViewModel,
                  CadastrarRequisicaoSaidaDto>();


        CreateMap<CadastrarRequisicaoSaidaDto,
                  RequisicaoSaida>();


        CreateMap<RequisicaoSaidaDto,
                  VisualizarRequisicaoSaidaViewModel>();
    }
}