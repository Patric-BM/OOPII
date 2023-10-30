
using System;

namespace InterfacesTest
{
   public class TarefaImportante : ITarefa {
    public string Descricao { get; set; }
    public bool Concluida { get; set; }
    public string Prioridade { get; set; }

    public TarefaImportante(string descricao, string prioridade) {
        Descricao = descricao;
        Concluida = false;
        Prioridade = prioridade;
    }

    public void ExibirDetalhes() {
        Console.WriteLine("Tarefa Importante: " + Descricao);
        Console.WriteLine("Prioridade: " + Prioridade);
        Console.WriteLine("Concluída: " + (Concluida ? "Sim" : "Não"));
    }
}
    
}