
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InterfacesTest;


class Program
{
    static void Main(string[] args)
    {
        string txtFilePath = "palavras.txt"; 
        IDatabaseConnection databaseConnection = new TextFileDatabaseConnection(txtFilePath);
        IPalavraProvider palavraProvider = new PalavraProvider(databaseConnection);
        IRegrasDoJogo regrasDoJogo = new RegrasDoJogo(palavraProvider.ObterPalavraAleatoria(out string categoria), categoria);
        IJogoDaForca jogo = new JogoDaForca(palavraProvider, regrasDoJogo);

        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Iniciar Jogo");
            Console.WriteLine("2 - Cadastrar Palavra");
            Console.WriteLine("3 - Sair");

            while (!int.TryParse(Console.ReadLine(), out opcao) || (opcao < 1 || opcao > 3))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            switch (opcao)
            {
                case 1:
                    jogo.Iniciar();
                    break;
                case 2:
                    CadastrarPalavra(databaseConnection);
                    break;
            }
        } while (opcao != 3);
    }

    static void CadastrarPalavra(IDatabaseConnection databaseConnection)
    {
        Console.Clear();
        Console.WriteLine("Digite a categoria da palavra:");
        string categoria = Console.ReadLine();

        Console.WriteLine("Digite a palavra:");
        string palavra = Console.ReadLine();

        ((TextFileDatabaseConnection)databaseConnection).CadastrarPalavra(categoria, palavra);

        Console.WriteLine("Palavra cadastrada com sucesso!");
        Console.WriteLine("Pressione qualquer tecla para continuar.");
        Console.ReadKey();
    }
}


