using Core.Models;
using Core.Services;

namespace Tests;

public class AuctionServiceTests
{
    [Fact]
    public void Test_NoWinner_WhenNoValidBids()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{50, 75}),
            new("B", new List<int>{80, 85})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(100, bidders);

        Assert.Equal("No Winner", result.Winner);
        Assert.Equal(100, result.WinningPrice);
    }

    [Fact]
    public void Test_SingleBidder_WinsWithHighestBid()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{120, 150})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(100, bidders);

        Assert.Equal("A", result.Winner); // L'unique enchérisseur gagne
        Assert.Equal(150, result.WinningPrice); // Leur enchère maximale est attribuée comme prix gagnant
    }

    [Fact]
    public void Test_MultipleBidders_OneWinner()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{50, 90}),
            new("B", new List<int>{120, 85}),
            new("C", new List<int>{60, 100})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(80, bidders);

        Assert.Equal("B", result.Winner); // L'enchérisseur B a la plus haute enchère valide (120)
        Assert.Equal(120, result.WinningPrice);
    }

    [Fact]
    public void Test_Tie_WithHighestBid()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{100}),
            new("B", new List<int>{100})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(50, bidders);

        Assert.Equal("A", result.Winner); // En cas d'égalité, la priorité est donnée au premier enchérisseur
        Assert.Equal(100, result.WinningPrice); // La plus haute enchère reste 100
    }

    [Fact]
    public void Test_OnlyBidsBelowReservePrice()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{30, 40}),
            new("B", new List<int>{20, 35}),
            new("C", new List<int>{10})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(50, bidders);

        Assert.Equal("No Winner", result.Winner); // Aucune enchère ne dépasse le prix de réserve
        Assert.Equal(50, result.WinningPrice);    // Résultat : prix de réserve
    }

    [Fact]
    public void Test_EmptyListOfBidders()
    {
        var bidders = new List<Bidder>(); // Liste vide

        var service = new AuctionService();
        var result  = service.DetermineWinner(50, bidders);

        Assert.Equal("No Winner", result.Winner); // Aucun participant, aucun gagnant
        Assert.Equal(50, result.WinningPrice);    // Prix de réserve
    }

    [Fact]
    public void Test_InvalidBids_AreIgnored()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{50, -10, 30}), // Une enchère négative est incluse (doit être ignorée)
            new("B", new List<int>{45, 0})       // Aucune enchère valide
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(40, bidders);

        Assert.Equal("A", result.Winner); // Seule l'enchérisseur A a une enchère valide au-dessus du prix de réserve
        Assert.Equal(50, result.WinningPrice); // La seule enchère valide et la plus élevée : 50
    }

    [Fact]
    public void Test_WinnerWithExactReservePrice()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{20, 50}),
            new("B", new List<int>{50}), // Enchère exacte au prix de réserve
            new("C", new List<int>{10})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(50, bidders);

        Assert.Equal("A", result.Winner);      // "A" devrait être premier dans la liste
        Assert.Equal(50, result.WinningPrice); // La plus haute enchère valide est 50
    }

    [Fact]
    public void Test_ReservePriceZero_AllBidsValid()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{20, 30}),
            new("B", new List<int>{15, 25}),
            new("C", new List<int>{10, 35})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(0, bidders); // Aucune restriction sur le prix de réserve

        Assert.Equal("C", result.Winner); // L'enchérisseur C est le gagnant avec 35
        Assert.Equal(35, result.WinningPrice);
    }
}