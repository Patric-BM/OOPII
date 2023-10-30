using System;

namespace InterfacesTest
{
  public class ListaDeTarefas {
    private List<ITarefa> tarefas = new List<ITarefa>();

    

    public void AdicionarTarefa(ITarefa tarefa) {
        tarefas.Add(tarefa);
    }

    public void ListarTarefas() {
        Console.WriteLine("Lista de Tarefas:");
        foreach (var tarefa in tarefas) {
            tarefa.ExibirDetalhes();
            Console.WriteLine();
        }
    }

    public void RemoverTarefa(ITarefa tarefa) {
        tarefas.Remove(tarefa);
    }

    public void EditarTarefa(ITarefa tarefa, string novaDescricao, bool novaConcluida) {
        tarefa.Descricao = novaDescricao;
        tarefa.Concluida = novaConcluida;
    }
}
}