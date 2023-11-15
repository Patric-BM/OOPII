
namespace InterfacesTest;

public class TextFileDatabaseConnection : TextDatabaseConnection
{
    public TextFileDatabaseConnection(string filePath) : base(filePath)
    {
    }

    public override void Salvar(Dictionary<int, Dictionary<string, List<string>>> data)
    {
        var lines = data.SelectMany(entry =>
            entry.Value.Select(category =>
                $"{entry.Key};{category.Key};{string.Join(",", category.Value)}"));

        File.WriteAllLines(_filePath, lines);
    }

    public override Dictionary<int, Dictionary<string, List<string>>> Carregar()
    {
        var wordsMap = new Dictionary<int, Dictionary<string, List<string>>>();

        if (File.Exists(_filePath))
        {
            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 3)
                {
                    int index = int.Parse(parts[0]);
                    string category = parts[1];
                    List<string> words = parts[2].Split(',').ToList();

                    if (!wordsMap.ContainsKey(index))
                    {
                        wordsMap[index] = new Dictionary<string, List<string>>();
                    }

                    wordsMap[index][category] = words;
                }
            }
        }

        return wordsMap;
    }

    public override void CadastrarPalavra(string categoria, string palavra)
    {
        var wordsMap = Carregar();

        if (!wordsMap.ContainsKey(categoria.GetHashCode()))
        {
            wordsMap.Add(categoria.GetHashCode(), new Dictionary<string, List<string>>());
        }

        if (!wordsMap[categoria.GetHashCode()].ContainsKey(categoria))
        {
            wordsMap[categoria.GetHashCode()][categoria] = new List<string>();
        }

        wordsMap[categoria.GetHashCode()][categoria].Add(palavra);

        Salvar(wordsMap);
    }
}