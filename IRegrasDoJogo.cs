
namespace InterfacesTest;
public interface IRegrasDoJogo
{
    bool TentarLetra(char letra);
    int TentativasRestantes { get; }
    bool JogoEncerrado { get; }
    bool JogadorVenceu { get; }

    string PalavraOculta { get; }
    string LetrasIncorretas { get; }
    string Categoria { get; } 
}