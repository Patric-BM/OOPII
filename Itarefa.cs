
namespace InterfacesTest
{
   public interface ITarefa {
    string Descricao { get; set; }
    bool Concluida { get; set; }

    void ExibirDetalhes();
}
}

