using System.Text.Json;

namespace ControleMedicamentosWeb.Compartilhado;

public class ContextoJson
{
    private const string CAMINHO_ARQUIVO =
        "dados.json";

    public DadosAplicacao Dados { get; private set; }
        = new();

    public void Carregar()
    {
        if (!File.Exists(CAMINHO_ARQUIVO))
        {
            Salvar();

            return;
        }

        string json =
            File.ReadAllText(CAMINHO_ARQUIVO);

        if (string.IsNullOrWhiteSpace(json))
        {
            Dados = new();

            return;
        }

        Dados =
            JsonSerializer.Deserialize<DadosAplicacao>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })
            ?? new DadosAplicacao();
    }

    public void Salvar()
    {
        string json =
            JsonSerializer.Serialize(
                Dados,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

        File.WriteAllText(
            CAMINHO_ARQUIVO,
            json);
    }
}