namespace ControleMedicamentosWeb.Compartilhado;

public interface IRepositorioBase<T>
{
    void Cadastrar(T registro);

    void Editar(T registroEditado);

    void Excluir(T registro);

    T? SelecionarPorId(Guid id);

    List<T> SelecionarTodos();
}