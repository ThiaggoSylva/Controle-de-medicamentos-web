using AutoMapper;

using ControleMedicamentosWeb.ModuloFornecedor.Dominio;
using ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.DTOs;
using ControleMedicamentosWeb.ModuloFornecedor.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloFornecedor.Apresentacao.Profiles;

public class FornecedorProfile : Profile
{
    public FornecedorProfile()
    {
        // Entidade -> DTO

        CreateMap<Fornecedor, FornecedorDto>();

        // DTO -> Entidade

        CreateMap<CadastrarFornecedorDto, Fornecedor>();

        CreateMap<EditarFornecedorDto, Fornecedor>();

        // ViewModel -> DTO

        CreateMap<CadastrarFornecedorViewModel,
                  CadastrarFornecedorDto>();

        CreateMap<EditarFornecedorViewModel,
                  EditarFornecedorDto>();

        // DTO -> ViewModel

        CreateMap<FornecedorDto,
                  VisualizarFornecedorViewModel>();

        CreateMap<FornecedorDto,
                  EditarFornecedorViewModel>();
    }
}