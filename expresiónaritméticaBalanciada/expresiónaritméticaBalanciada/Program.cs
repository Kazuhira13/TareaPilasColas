using expresiónaritméticaBalanciada;
class Program  
{
    static void Main()
    {
        string expresion = "(((x + 1) - 3) * (x * x + 2) - 4) + (x - 1)";
        Console.WriteLine(balance.EstaBalanceada(expresion) ? "La expresión está balanceada" : "La expresión NO está balanceada");
    }
}