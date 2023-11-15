
namespace InterfacesTest;

public class PalavraProvider : IPalavraProvider
{
    private readonly IDatabaseConnection _databaseConnection;
    private Dictionary<int, Dictionary<string, List<string>>> _wordsMap;

    public PalavraProvider(IDatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
        CarregarPalavras();
    }

    private void CarregarPalavras()
    {
        _wordsMap = _databaseConnection.Carregar();
    }

    public string ObterPalavraAleatoria(out string categoria)
    {
        Random random = new Random();

        if (_wordsMap == null || !_wordsMap.Any())
        {
            categoria = "";
            return "";
        }

        int index = random.Next(0, _wordsMap.Count);
        Dictionary<string, List<string>> category = _wordsMap.ElementAt(index).Value;
        List<string> selectedWords = category.Values.First();
        int indexWord = random.Next(0, selectedWords.Count);
        categoria = category.Keys.First();
        return selectedWords[indexWord];
    }

    public void CadastrarPalavra(string categoria, string palavra)
    {
        _databaseConnection.CadastrarPalavra(categoria, palavra); 
    }
}