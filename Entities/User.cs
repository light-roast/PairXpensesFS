namespace PairXpensesFS;
using System.Collections.Generic;


public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public long Total { get; set; } = 0;
    public long TotalDebt { get; set; } = 0;

    public List<Debt>? Debts {get; set;}

    public List<Payment>? Payments {get; set;}


}