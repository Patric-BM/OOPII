
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
        
        
           while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Jogo da Forca");
                    Console.WriteLine("1 - Jogar");
                    Console.WriteLine("2 - Cadastrar palavra");
                    Console.WriteLine("3 - Sair");
                    Console.Write("Digite uma opção: ");
                    opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            jogo.Iniciar();
                            break;
                        case 2:
                            CadastrarPalavra(databaseConnection);
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Opção inválida!");
                }
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
            }
        }

          
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


