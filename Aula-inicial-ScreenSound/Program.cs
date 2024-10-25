//Projeto Sreen Sound
using System.ComponentModel;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string>();  //criando uma lista <> informa o tipo da lista

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>(); //criando um dicionario vazio
bandasRegistradas.Add("Falamansa", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("Mamonas Assassinas", new List<int>());
void ExibirLogo()
{
    Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção:");
    string opcaoEscolhida = Console.ReadLine()!; //usando o ! para não receber valor nulo pq a string permite
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            ExibirMedia();    
            break;
        case -1:
            Console.WriteLine("Você escolheu a opção" + opcaoEscolhidaNumerica);
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de bandas");
    
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    // listaDasBandas.Add(nomeDaBanda); // incluindo na lista
    bandasRegistradas.Add(nomeDaBanda, new List<int>()); //criando uma lista dentro do registro da banda
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    Thread.Sleep(2000);//esperar um pouco
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo as bandas registradas");
    

    /*for (int i = 0; i < listaDasBandas.Count; i++)
    {
        Console.WriteLine($"Banda: {listaDasBandas[i]}");
    }*/

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    
    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey(); //vai para o menu principal
  
}

void ExibirTituloDaOpcao (string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*'); //pegar uma qtd de * e adiciona em uma string, total da qtd * com o tamanho (qtd de coisas a esquerda)
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota); //[] indexar o dicionario usando a chave, acesso os valores em lista - lista de notas, pega a chave
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi registrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
        Console.ReadKey();
        Console.Clear();
    }
}

void ExibirMedia()
{
    Console.Clear() ;
    ExibirTituloDaOpcao("Exibir Média da Banda");
    Console.WriteLine("Digite o nome da banda que deseja exibir a média:");
    string nomeDaBanda = Console.ReadLine()!;
    //verificar se existe no dicionario
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        //pegar todas as notas - lista
        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        //função C# que exibe a média
        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey() ; 
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"\n A banda {nomeDaBanda} não foi encontrada.");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal.");
        Console.ReadKey() ;
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();
