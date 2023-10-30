
using System;

namespace InterfacesTest
{
 public class TarefaSimples : ITarefa {
    public string Descricao { get; set; }
    public bool Concluida { get; set; }

    public TarefaSimples(string descricao) {
        Descricao = descricao;
        Concluida = false;
    }

    public void ExibirDetalhes() {
        Console.WriteLine("Tarefa Simples: " + Descricao);
        Console.WriteLine("Concluída: " + (Concluida ? "Sim" : "Não"));
    }
}
}