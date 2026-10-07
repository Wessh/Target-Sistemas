using System.Text.Json;

namespace Target_Sistemas.Atividades;

public class Segunda
{
    readonly List<Movimentacao> movimentacoes = new();

    public void Executar()
    {
        var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var dados = JsonSerializer.Deserialize<Dados>(Json, opt)!;

        while (true)
        {
            Console.WriteLine("\nProdutos:");
            foreach (var p in dados.Estoque)
                Console.WriteLine($"{p.CodigoProduto} - {p.DescricaoProduto} ({p.Estoque})");

            Console.Write("\nCódigo do produto (0 para sair): ");
            if (!int.TryParse(Console.ReadLine(), out var cod))
            {
                Console.WriteLine("Código inválido.");
                continue;
            }
            if (cod == 0) break;

            var produto = dados.Estoque.FirstOrDefault(p => p.CodigoProduto == cod);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                continue;
            }

            Console.Write("Tipo (1 - Entrada, 2 - Saída): ");
            var tipo = Console.ReadLine();
            if (tipo != "1" && tipo != "2")
            {
                Console.WriteLine("Tipo inválido.");
                continue;
            }

            Console.Write("Quantidade: ");
            if (!int.TryParse(Console.ReadLine(), out var qtd) || qtd <= 0)
            {
                Console.WriteLine("Quantidade inválida.");
                continue;
            }

            if (tipo == "2" && qtd > produto.Estoque)
            {
                Console.WriteLine("Estoque insuficiente.");
                continue;
            }

            Console.Write("Descrição (ex: compra, venda, devolução): ");
            var desc = Console.ReadLine() ?? "";

            produto.Estoque += tipo == "1" ? qtd : -qtd;
            var movimentacao = new Movimentacao(movimentacoes.Count + 1, cod, tipo == "1" ? "Entrada" : "Saída", qtd, desc);
            movimentacoes.Add(movimentacao);

            Console.WriteLine($"Movimentação {movimentacao.Id} ({movimentacao.Tipo} - {movimentacao.Descricao}) registrada.");
            Console.WriteLine($"Estoque final de {produto.DescricaoProduto}: {produto.Estoque}");
        }
    }

    class Produto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = "";
        public int Estoque { get; set; }
    }

    record Movimentacao(int Id, int Codigo, string Tipo, int Qtd, string Descricao);
    record Dados(List<Produto> Estoque);

    const string Json = """
    {
      "estoque": [
        { "codigoProduto": 101, "descricaoProduto": "Caneta Azul", "estoque": 150 },
        { "codigoProduto": 102, "descricaoProduto": "Caderno Universitário", "estoque": 75 },
        { "codigoProduto": 103, "descricaoProduto": "Borracha Branca", "estoque": 200 },
        { "codigoProduto": 104, "descricaoProduto": "Lápis Preto HB", "estoque": 320 },
        { "codigoProduto": 105, "descricaoProduto": "Marcador de Texto Amarelo", "estoque": 90 }
      ]
    }
    """;
}