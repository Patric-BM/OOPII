

namespace InterfacesTest;

public class JogoDaForca : IJogoDaForca
{
    private readonly IPalavraProvider _palavraProvider;
    private IRegrasDoJogo _regrasDoJogo;

    public JogoDaForca(IPalavraProvider palavraProvider, IRegrasDoJogo regrasDoJogo)
    {
        _palavraProvider = palavraProvider;
        _regrasDoJogo = regrasDoJogo;
    }

    public void Iniciar()
    {
        while (!_regrasDoJogo.JogoEncerrado)
        {
            Console.Clear();
            Console.WriteLine(" -  Jogo da Forca - ");
            Console.WriteLine();
            Console.WriteLine($"Erros: {_regrasDoJogo.TentativasRestantes} de 6\n");
            Console.WriteLine($"Tente adivinhar a palavra da Categoria: {_regrasDoJogo.Categoria}");
            if (_regrasDoJogo.TentativasRestantes == 0)
            {
                ShowHangman();
                Console.WriteLine("Você perdeu!");
                Console.WriteLine($"A palavra era: {_regrasDoJogo.PalavraOculta}");
                GameQuit();
            }
            else
            {
                ShowHangman();
            }

            Console.WriteLine($"Letras erradas: {_regrasDoJogo.LetrasIncorretas}");
            Console.WriteLine(_regrasDoJogo.PalavraOculta);

            Console.WriteLine("Digite uma letra:");
            char letra = GetValidLetter();

            if (!_regrasDoJogo.TentarLetra(letra))
            {
                Console.WriteLine("Erro: A letra já foi tentada.");
                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadKey();
            }
        }

        if (_regrasDoJogo.JogadorVenceu)
        {
            Console.Clear();
            Console.WriteLine("Você ganhou!");
            Console.WriteLine($"A palavra era: {_regrasDoJogo.PalavraOculta}");
        }

        GameQuit();
    }

    private void ShowHangman()
    {
        string[] hangmanDesign = {
            @"
    _______
   |       |
           |
           |
           |
           |
",
            @"
    _______
   |       |
   O       |
           |
           |
           | 
",
            @"
    _______
   |       |
   O       |
   |       |
           |
           |
",
            @"
    _______
   |       |
   O       |
  /|       |
           |
           |
",
            @"
    _______
   |       |
   O       |
  /|\      |
           |
           |
",
            @"
    _______
   |       |
   O       |
  /|\      |
  /        |
           |
",
            @"
    _______
   |       |
   O       |
  /|\      |
  / \      |
           |
"
        };

        Console.WriteLine(hangmanDesign[6 - _regrasDoJogo.TentativasRestantes]);
    }

    private char GetValidLetter()
    {
        char letra;
        if (!char.TryParse(Console.ReadLine(), out letra))
        {
            throw new ArgumentException("Entrada inválida. Digite apenas uma letra.");
        }

        letra = char.ToLower(letra);
        if (!char.IsLetter(letra))
        {
            throw new ArgumentException("Entrada inválida. Digite apenas uma letra.");
        }

        return letra;
    }

    private void GameQuit()
    {
        Console.WriteLine("Deseja jogar novamente? (S para sim, qualquer outra tecla para sair)");
        char resposta = char.ToLower(Console.ReadKey().KeyChar);
        if (resposta == 's')
        {
            Console.Clear();
            _regrasDoJogo = new RegrasDoJogo(_palavraProvider.ObterPalavraAleatoria(out string categoria), categoria);
            Iniciar();
        }
        else
        {
            Environment.Exit(0);
        }
    }
}