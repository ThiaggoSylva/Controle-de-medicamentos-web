using AutoMapper;

using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Dominio;
using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloRequisicaoEntrada.Apresentacao.Profiles;

public class RequisicaoEntradaProfile : Profile
{
    public RequisicaoEntradaProfile()
    {
        CreateMap<CadastrarRequisicaoEntradaViewModel,
                  CadastrarRequisicaoEntradaDto>();


        CreateMap<CadastrarRequisicaoEntradaDto,
                  RequisicaoEntrada>();


        CreateMap<RequisicaoEntradaDto,
                  VisualizarRequisicaoEntradaViewModel>();
    }
}