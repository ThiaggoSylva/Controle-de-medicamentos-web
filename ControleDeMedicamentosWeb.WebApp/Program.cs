using ControleMedicamentosWeb.Compartilhado;

var builder = WebApplication.CreateBuilder(args);

ContextoJson contexto = new();

contexto.Carregar();

builder.Services.AddSingleton(contexto);

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

builder.Services.AddAutoMapper(
    AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern:
        "{controller=Fornecedor}/{action=Index}/{id?}");

app.Run();