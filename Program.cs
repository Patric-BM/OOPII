using System;
namespace InterfacesTest {

    class Program {
        static void Main(string[] args) {

            /// Esse programa imagina que estamos criando um aplicativo de lista de tarefas com interfaces. Porém, essa é uma impelemntação simpes, apenas para demonstrar o uso de interfaces.     

        ITarefa tarefa1 = new TarefaSimples("Comprar mantimentos");
        ITarefa tarefa2 = new TarefaImportante("Estudar para o exame", "Alta");
        ITarefa tarefa3 = new TarefaSimples("Fazer exercícios");

        ListaDeTarefas listaDeTarefas = new ListaDeTarefas();

        listaDeTarefas.AdicionarTarefa(tarefa1);
        listaDeTarefas.AdicionarTarefa(tarefa2);
        listaDeTarefas.AdicionarTarefa(tarefa3);        


        Console.WriteLine("Listando tarefas... \n");
        listaDeTarefas.ListarTarefas();

        Console.WriteLine("Removendo tarefa 1... \n");
        listaDeTarefas.RemoverTarefa(tarefa1);

        Console.WriteLine("Editando tarefa 2... \n");
        listaDeTarefas.EditarTarefa(tarefa2, "Estudar para o exame final", true);


        Console.WriteLine("Listando tarefas atualizadas... \n");
        listaDeTarefas.ListarTarefas();
        }

    }
}