using ControleMedicamentosWeb.Compartilhado;
using Microsoft.AspNetCore.Mvc.Razor;

using ControleMedicamentosWeb.ModuloFornecedor.Dominio;
using ControleMedicamentosWeb.ModuloFornecedor.Infraestrutura;
using ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloPaciente.Dominio;
using ControleMedicamentosWeb.ModuloPaciente.Infraestrutura;
using ControleMedicamentosWeb.ModuloPaciente.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloMedicamento.Dominio;
using ControleMedicamentosWeb.ModuloMedicamento.Infraestrutura;
using ControleMedicamentosWeb.ModuloMedicamento.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloFuncionario.Dominio;
using ControleMedicamentosWeb.ModuloFuncionario.Infraestrutura;
using ControleMedicamentosWeb.ModuloFuncionario.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Dominio;
using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Infraestrutura;
using ControleMedicamentosWeb.ModuloRequisicaoEntrada.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloRequisicaoSaida.Dominio;
using ControleMedicamentosWeb.ModuloRequisicaoSaida.Infraestrutura;
using ControleMedicamentosWeb.ModuloRequisicaoSaida.Aplicacao.Servicos;

var builder = WebApplication.CreateBuilder(args);

#region Contexto Json

ContextoJson contexto = new();

contexto.Carregar();

builder.Services.AddSingleton(contexto);

#endregion

#region MVC

builder.Services
.AddControllersWithViews()
.AddRazorOptions(options =>
{
    options.ViewLocationFormats.Add(
    "/Modulo{1}/Apresentacao/Views/{1}/{0}.cshtml");

    options.ViewLocationFormats.Add(
        "/Modulo{1}/Apresentacao/Views/{0}.cshtml");

    options.ViewLocationFormats.Add(
        "/Compartilhado/Apresentacao/Views/{0}.cshtml");
});

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Add(
        "/ModuloEstoque/ModuloRequisicaoEntrada/Apresentacao/Views/{1}/{0}.cshtml");

    options.ViewLocationFormats.Add(
        "/ModuloEstoque/ModuloRequisicaoEntrada/Apresentacao/Views/{0}.cshtml");

    options.ViewLocationFormats.Add(
        "/ModuloEstoque/ModuloRequisicaoSaida/Apresentacao/Views/{1}/{0}.cshtml");

    options.ViewLocationFormats.Add(
        "/ModuloEstoque/ModuloRequisicaoSaida/Apresentacao/Views/{0}.cshtml");
});


#endregion

#region AutoMapper

builder.Services.AddAutoMapper(
AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region 

builder.Services.AddScoped<IRepositorioFornecedor,
RepositorioFornecedorEmArquivo>();

builder.Services.AddScoped<IServicoFornecedor,
ServicoFornecedor>();

builder.Services.AddScoped<IRepositorioPaciente,
                           RepositorioPacienteEmArquivo>();

builder.Services.AddScoped<IServicoPaciente,
                           ServicoPaciente>();

builder.Services.AddScoped<IRepositorioPaciente,
                           RepositorioPacienteEmArquivo>();

builder.Services.AddScoped<IServicoPaciente,
                           ServicoPaciente>();

builder.Services.AddScoped<IRepositorioMedicamento,
                           RepositorioMedicamentoEmArquivo>();

builder.Services.AddScoped<IServicoMedicamento,
                           ServicoMedicamento>();

builder.Services.AddScoped<IRepositorioFuncionario,
                           RepositorioFuncionarioEmArquivo>();

builder.Services.AddScoped<IServicoFuncionario,
                           ServicoFuncionario>();

builder.Services.AddScoped<IRepositorioRequisicaoEntrada,
                            RepositorioRequisicaoEntradaEmArquivo>();

builder.Services.AddScoped<IServicoRequisicaoEntrada,
                            ServicoRequisicaoEntrada>();

builder.Services.AddScoped<IRepositorioRequisicaoSaida,
                            RepositorioRequisicaoSaidaEmArquivo>();

builder.Services.AddScoped<IServicoRequisicaoSaida,
                            ServicoRequisicaoSaida>();

#endregion

var app = builder.Build();

#region Pipeline

if (!app.Environment.IsDevelopment())
{
app.UseExceptionHandler("/Home/Error");

app.UseHsts();

}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
name: "default",
pattern: "{controller=Fornecedor}/{action=Index}/{id?}");

#endregion

app.Run();
