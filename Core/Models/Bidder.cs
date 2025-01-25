namespace Core.Models;

public class Bidder
{
    public string Name { get; set; }
    public List<int> Bids { get; set; }
      
    public Bidder(string name, List<int> bids)
    {
        Name = name;
        Bids = bids;
    }

    public Bidder()
    {}
}