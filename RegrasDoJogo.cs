
namespace InterfacesTest;
public class RegrasDoJogo : IRegrasDoJogo
{
    private readonly string _palavra;
    private readonly List<char> _letras;
    private string _letrasIncorretas;
    private readonly string _categoria; 
    private int _tentativas;

    public RegrasDoJogo(string palavra, string categoria)
    {
        _palavra = palavra;
        _categoria = categoria;
        _letras = new List<char>();
        _letrasIncorretas = "";
        _tentativas = 0;

        for (int i = 0; i < _palavra.Length; i++)
        {
            _letras.Add('_');
        }
    }

    public bool TentarLetra(char letra)
    {
        if (_tentativas >= 6)
        {
            return false;
        }

        bool acertou = false;
        for (int i = 0; i < _palavra.Length; i++)
        {
            if (_palavra[i] == letra)
            {
                _letras[i] = letra;
                acertou = true;
            }
        }

        if (!acertou)
        {
            _letrasIncorretas += letra + " ";
            _tentativas++;
        }

        return true;
    }

    public int TentativasRestantes => 6 - _tentativas;

    public bool JogoEncerrado => _tentativas >= 6 || _letras.All(c => c != '_');

    public bool JogadorVenceu => _letras.All(c => c != '_') && _tentativas < 6;

    public string PalavraOculta => new string(_letras.ToArray());

    public string LetrasIncorretas => _letrasIncorretas;

    public string Categoria => _categoria;
}