using System.Globalization;

namespace Target_Sistemas.Atividades;

public class Terceira
{
    public void Executar()
    {
        var cultura = new CultureInfo("pt-BR");

        Console.Write("Valor: ");
        if (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number, cultura, out var valor) || valor <= 0)
        {
            Console.WriteLine("Valor inválido.");
            return;
        }

        Console.Write("Data de vencimento (dd/MM/aaaa): ");
        if (!DateTime.TryParse(Console.ReadLine(), cultura, DateTimeStyles.None, out var vencimento))
        {
            Console.WriteLine("Data inválida.");
            return;
        }

        var dias = (DateTime.Today - vencimento.Date).Days;
        if (dias <= 0)
        {
            Console.WriteLine("Sem atraso, não há juros.");
            return;
        }

        var juros = valor * 0.025m * dias;

        Console.WriteLine($"Dias de atraso: {dias}");
        Console.WriteLine($"Juros: {juros.ToString("C", cultura)}");
        Console.WriteLine($"Total: {(valor + juros).ToString("C", cultura)}");
    }
}