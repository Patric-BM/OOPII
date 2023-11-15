
namespace InterfacesTest;

public abstract class TextDatabaseConnection : IDatabaseConnection
{
    protected readonly string _filePath;

    protected TextDatabaseConnection(string filePath)
    {
        _filePath = filePath;
    }

    public abstract void Salvar(Dictionary<int, Dictionary<string, List<string>>> data);
    public abstract Dictionary<int, Dictionary<string, List<string>>> Carregar();
    public abstract void CadastrarPalavra(string categoria, string palavra);
}