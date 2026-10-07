# Target Sistemas - Desafio

Solução das três atividades do desafio, em C# / .NET, como aplicação de console.

## Como rodar

```
dotnet run
```
Ao iniciar, aparece um menu para escolher qual atividade executar.

## Atividades

**1 - Comissões (`Primeira.cs`)**
Lê as vendas e calcula a comissão total de cada vendedor, por venda:
- abaixo de R$ 100,00: sem comissão
- de R$ 100,00 até R$ 499,99: 1%
- a partir de R$ 500,00: 5%

**2 - Estoque (`Segunda.cs`)**
Permite lançar entradas e saídas de produtos. Cada movimentação tem um id único e uma descrição, e ao final é exibido o estoque atualizado do produto. Não permite saída maior que o estoque disponível.

**3 - Juros (`Terceira.cs`)**
Recebe um valor e uma data de vencimento e calcula os juros até hoje, com multa de 2,5% ao dia sobre o valor original (juros simples).

## Observações

- O JSON das atividades 1 e 2 está embutido no código (constante no fim da classe), para o projeto rodar sem configuração extra.
- Valores monetários usam `decimal` para evitar erros de arredondamento.
