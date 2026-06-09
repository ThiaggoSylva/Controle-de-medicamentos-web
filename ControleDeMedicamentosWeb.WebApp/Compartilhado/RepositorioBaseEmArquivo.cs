namespace ControleMedicamentosWeb.Compartilhado;

public abstract class RepositorioBaseEmArquivo<T>
    : IRepositorioBase<T>
    where T : EntidadeBase<T>
{
    protected readonly ContextoJson contexto;

    protected RepositorioBaseEmArquivo(
        ContextoJson contexto)
    {
        this.contexto = contexto;
    }

    protected abstract List<T> ObterRegistros();

    public virtual void Cadastrar(T registro)
    {
        ObterRegistros().Add(registro);

        contexto.Salvar();
    }

    public virtual void Editar(T registroEditado)
    {
        T? registroSelecionado =
            SelecionarPorId(registroEditado.Id);

        if (registroSelecionado is null)
            return;

        registroSelecionado.AtualizarRegistro(
            registroEditado);

        contexto.Salvar();
    }

    public virtual void Excluir(T registro)
    {
        ObterRegistros().Remove(registro);

        contexto.Salvar();
    }

    public virtual T? SelecionarPorId(Guid id)
    {
        return ObterRegistros()
            .FirstOrDefault(x => x.Id == id);
    }

    public virtual List<T> SelecionarTodos()
    {
        return ObterRegistros();
    }
}