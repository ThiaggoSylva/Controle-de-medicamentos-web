using ControleMedicamentosWeb.Compartilhado;

using ControleMedicamentosWeb.ModuloFornecedor.Dominio;
using ControleMedicamentosWeb.ModuloFornecedor.Infraestrutura;
using ControleMedicamentosWeb.ModuloFornecedor.Aplicacao.Servicos;
using ControleMedicamentosWeb.ModuloPaciente.Dominio;
using ControleMedicamentosWeb.ModuloPaciente.Infraestrutura;
using ControleMedicamentosWeb.ModuloPaciente.Aplicacao.Servicos;

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


#endregion

#region AutoMapper

builder.Services.AddAutoMapper(
AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region Fornecedor

builder.Services.AddScoped<IRepositorioFornecedor,
RepositorioFornecedorEmArquivo>();

builder.Services.AddScoped<IServicoFornecedor,
ServicoFornecedor>();

#endregion

#region Paciente

builder.Services.AddScoped<IRepositorioPaciente,
                           RepositorioPacienteEmArquivo>();

builder.Services.AddScoped<IServicoPaciente,
                           ServicoPaciente>();

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
