
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
        if (_letras.Contains(letra))
        {
            return false;
        }

        if (_palavra.Contains(letra))
        {
            for (int i = 0; i < _palavra.Length; i++)
            {
                if (_palavra[i] == letra)
                {
                    _letras[i] = letra;
                }
            }
        }
        else
        {
            _letrasIncorretas += letra;
            _tentativas++;
        }

        return true;
    }

    public int TentativasRestantes => 6 - _tentativas;

    public bool JogoEncerrado => _letras.Contains('_') && _tentativas >= 6;

    public bool JogadorVenceu => !_letras.Contains('_');

    public string PalavraOculta => new string(_letras.ToArray());

    public string LetrasIncorretas => _letrasIncorretas;

    public string Categoria => _categoria;
}