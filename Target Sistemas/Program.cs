
using Target_Sistemas.Atividades;

while (true)
{
    Console.WriteLine("\n1 - Primeira (comissões)");
    Console.WriteLine("2 - Segunda (estoque)");
    Console.WriteLine("3 - Terceira (juros)");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha: ");

    switch (Console.ReadLine())
    {
        case "1": new Primeira().Executar(); break;
        case "2": new Segunda().Executar(); break;
        case "3": new Terceira().Executar(); break;
        case "0": return;
        default: Console.WriteLine("Opção inválida."); break;
    }
}