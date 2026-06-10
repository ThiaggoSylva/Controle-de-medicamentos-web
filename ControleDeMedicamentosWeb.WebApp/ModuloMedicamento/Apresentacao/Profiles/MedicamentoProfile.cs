using AutoMapper;

using ControleMedicamentosWeb.ModuloMedicamento.Dominio;

using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.DTOs;

using ControleMedicamentosWeb.ModuloMedicamento.Apresentacao.Models;

namespace ControleMedicamentosWeb.ModuloMedicamento.Apresentacao.Profiles;

public class MedicamentoProfile : Profile
{
    public MedicamentoProfile()
    {
        CreateMap<CadastrarMedicamentoViewModel,
                  CadastrarMedicamentoDto>();

        CreateMap<EditarMedicamentoViewModel,
                  EditarMedicamentoDto>();


        CreateMap<CadastrarMedicamentoDto,
                  Medicamento>();

        CreateMap<EditarMedicamentoDto,
                  Medicamento>();


        CreateMap<Medicamento,
                  MedicamentoDto>()
            .ForCtorParam(
                nameof(MedicamentoDto.Id),
                opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(
                nameof(MedicamentoDto.Nome),
                opt => opt.MapFrom(src => src.Nome))
            .ForCtorParam(
                nameof(MedicamentoDto.Descricao),
                opt => opt.MapFrom(src => src.Descricao))
            .ForCtorParam(
                nameof(MedicamentoDto.QuantidadeEstoque),
                opt => opt.MapFrom(src => src.QuantidadeEstoque))
            .ForCtorParam(
                nameof(MedicamentoDto.FornecedorId),
                opt => opt.MapFrom(src => src.FornecedorId))
            .ForCtorParam(
                nameof(MedicamentoDto.NomeFornecedor),
                opt => opt.MapFrom(src => string.Empty))
            .ForCtorParam(
                nameof(MedicamentoDto.EmFalta),
                opt => opt.MapFrom(src => src.EmFalta));


        CreateMap<MedicamentoDto,
                  VisualizarMedicamentoViewModel>();


        CreateMap<MedicamentoDto,
                  EditarMedicamentoViewModel>();
    }
}