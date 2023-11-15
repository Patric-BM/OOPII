

namespace InterfacesTest;
public interface IPalavraProvider
{
    string ObterPalavraAleatoria(out string categoria);
    void CadastrarPalavra(string categoria, string palavra);
}