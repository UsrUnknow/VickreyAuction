namespace Core.Models;

public class Bid
{
    public int Amount { get; set; }
    public Bid(int amount) => Amount = amount;
}