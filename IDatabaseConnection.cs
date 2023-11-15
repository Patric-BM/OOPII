
namespace InterfacesTest;

public interface IDatabaseConnection
{
    void Salvar(Dictionary<int, Dictionary<string, List<string>>> data);
    Dictionary<int, Dictionary<string, List<string>>> Carregar();
    void CadastrarPalavra(string categoria, string palavra);
}