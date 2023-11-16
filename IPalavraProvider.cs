

namespace InterfacesTest;
public interface IPalavraProvider
{
    string ObterPalavraAleatoria(out string categoria);
    string ObterPalavraSelecionada();
    void CadastrarPalavra(string categoria, string palavra);
}