
namespace InterfacesTest;

public static class Validators
{
        public static char GetValidLetter()
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


}