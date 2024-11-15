using System.ComponentModel;
using System.Runtime.Intrinsics.X86;

string mensagemDeBoasVindas = "Bem vindo ao Screen Music";
//List<string> ListaDasBandas = new List<string> { "One Direction", "Little Mix", "CNCO" };
Dictionary<string, List<int>> bandas = new Dictionary<string, List<int>>();
bandas.Add("One Direction", new List<int> { 10, 8, 6 });
bandas.Add("Little Mix", new List<int>());
void ExibirLogo()
{
    Console.WriteLine(@"


░██████╗░█████╗░███╗░░░███╗  ███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░
██╔════╝██╔══██╗████╗░████║  ████╗░████║██║░░░██║██╔════╝██║██╔══██╗
╚█████╗░██║░░██║██╔████╔██║  ██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝
░╚═══██╗██║░░██║██║╚██╔╝██║  ██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗
██████╔╝╚█████╔╝██║░╚═╝░██║  ██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝
╚═════╝░░╚════╝░╚═╝░░░░░╚═╝  ╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média da banda");
    Console.WriteLine("Digite 5 para sair");

    Console.Write("\nDigite a sua opção: ");
    String opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMediaDaBanda();
            break;
        case 5: Console.WriteLine("Bye Bye");
            break;
        default: Console.WriteLine("Opção invalida");
            break;
    }   
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTitulodaOpcao("Registro das bandas");
    Console.WriteLine("*******************");
    Console.WriteLine("Registro de banda");
    Console.WriteLine("*******************\n");
    Console.WriteLine("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada!");
    Thread.Sleep(2000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTitulodaOpcao("Exibindo todas as bandas registradas");

    //for (int i = 0; i < ListaDasBandas.Count; i++) 
   // {
       // Console.WriteLine($"Banda: {ListaDasBandas[i]}");
   // }
   foreach (string banda in bandas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para retornar ao menu");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void ExibirTitulodaOpcao(string titulo)
{ 
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //digitar a banda que irá avaliar
    //se a banda estiver no dicionario >> colocar uma nota
    //senão retorna ao menu principal

    Console.Clear();
    ExibirTitulodaOpcao("Avaliar banda");
    Console.Write("Escreva o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandas.ContainsKey(nomeDaBanda))
    {
        Console.WriteLine($"Qual nota deseja dar a {nomeDaBanda}: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandas[nomeDaBanda].Add(nota);
        Console.WriteLine($"A nota {nota} foi registrada;");
        Thread.Sleep(5000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para retornar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTitulodaOpcao("Exibir média da banda");
    Console.Write("Escreva o nome da banda que deseja ver a média: ");
    string nomeDaBanda = Console.ReadLine()!;
    if ( bandas.ContainsKey(nomeDaBanda))
    {
        List<int> notasDaBanda = bandas[nomeDaBanda];
        Console.WriteLine($" A média da banda {nomeDaBanda} é {notasDaBanda.Average()}");
        Console.WriteLine("Digite uma tecla para retornar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para retornar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

ExibirOpcoesDoMenu();