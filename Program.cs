// Screen Sound
string helloMessage = "Welcome to Screen Sound!";
//List<string> listaDasBandas = new List<string>();
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Projeto Sola", new List<int> {10, 9, 7});
bandasRegistradas.Add("Kami Kam", new List<int> ());

void exibirMensagemBoasVindas () 
{
    Console.WriteLine(@"
    
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine(helloMessage);
} 

void exibirOpcoesMenu () 
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para consultar bandas registradas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para mostrar a media de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a opção desejada: ");
    String opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    
    switch (opcaoEscolhidaNumerica) 
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas(); 
            break;
        case 3: AvaliarBanda(); 
            break;
        case 4: ExibirMediaDaBanda(); 
            break;
        case -1: Console.WriteLine("Tchau! ;D"); 
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDasOpcoes("Registrar Banda");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda, new List<int>());
    Console.Write($"A banda {nomeBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);
    exibirOpcoesMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDasOpcoes("Bandas Registradas");
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Thread.Sleep(2000);
    Console.WriteLine("Digite qualquer tecla para voltar ao menu");
    Console.ReadKey();
    Console.Clear();
    exibirOpcoesMenu();
}

void AvaliarBanda()
{
    Console.Clear();
    ExibirTituloDasOpcoes("Avaliação de Bandas");
    Console.Write("Qual banda deseja avaliar? R: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write("Digite uma nota para a banda: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA banda {nomeDaBanda} foi avaliada com a nota {nota} com sucesso!");
        Thread.Sleep(2000);
        Console.Clear();
        exibirOpcoesMenu();
    } else 
    {
        Console.WriteLine($"A banda {nomeDaBanda} não encontrada");
        Console.WriteLine("Digite qualquer tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        exibirOpcoesMenu();
    }
}

void ExibirMediaDaBanda()
{
    Console.Clear();
    ExibirTituloDasOpcoes("Média de Bandas");
    Console.Write("Você deseja ver a média de qual banda? R: ");
    string nomeDaBanda = Console.ReadLine()!;
    switch (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        case true:
            if (bandasRegistradas[nomeDaBanda].Count > 0)
            {
                double media = bandasRegistradas[nomeDaBanda].Average();
                Console.WriteLine($"A média da banda {nomeDaBanda} é {media}");
                Thread.Sleep(1500);
                Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                exibirOpcoesMenu();
            } else
            {
                Console.WriteLine($"A banda {nomeDaBanda} não possui avaliações");
                Thread.Sleep(1500);
                Console.WriteLine("\nDigite qualquer tecla para voltar ao menu");
                Console.ReadKey();
                Console.Clear();
                exibirOpcoesMenu();
            } break;
        case false:
            Console.WriteLine($"A banda {nomeDaBanda} não faz parte do nosso registro\n \nDigite qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
            exibirOpcoesMenu();
            break;

    }
}

void ExibirTituloDasOpcoes(string titulo)
{
    int quantidadeCaracteres = titulo.Length;
    string asteriscos =string.Empty.PadLeft(quantidadeCaracteres, '*' );
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
} 

exibirMensagemBoasVindas();
exibirOpcoesMenu();