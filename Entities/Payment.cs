namespace PairXpensesFS;

public class Payment
{
    public int Id { get; set; }
    public required string Name {get; set;}

   public long Value { get; set; }
   public DateTime CreateDate { get; set; } = DateTime.Now;
   public DateTime UpdateDate { get; set; } = DateTime.Now;
   public required User User {get; set;} = null!;
}