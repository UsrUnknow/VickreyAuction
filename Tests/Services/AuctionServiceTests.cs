using Core.Models;
using Core.Services;

namespace Tests.Services;

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

        Assert.Equal("A", result.Winner);
        Assert.Equal(120, result.WinningPrice);
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

        Assert.Equal("B", result.Winner);
        Assert.Equal(100, result.WinningPrice);
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

        Assert.Equal("A", result.Winner);
        Assert.Equal(100, result.WinningPrice);
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

        Assert.Equal("No Winner", result.Winner);
        Assert.Equal(50, result.WinningPrice);
    }

    [Fact]
    public void Test_EmptyListOfBidders()
    {
        var bidders = new List<Bidder>();

        var service = new AuctionService();
        var result  = service.DetermineWinner(50, bidders);

        Assert.Equal("No Winner", result.Winner);
        Assert.Equal(50, result.WinningPrice);
    }

    [Fact]
    public void Test_InvalidBids_AreIgnored()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{50, -10, 30}),
            new("B", new List<int>{45, 0})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(40, bidders);

        Assert.Equal("A", result.Winner);
        Assert.Equal(45, result.WinningPrice);
    }

    [Fact]
    public void Test_WinnerWithExactReservePrice()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{20, 50}),
            new("B", new List<int>{50}),
            new("C", new List<int>{10})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(50, bidders);

        Assert.Equal("A", result.Winner);
        Assert.Equal(50, result.WinningPrice);
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

        Assert.Equal("C", result.Winner);
        Assert.Equal(30, result.WinningPrice);
    }
    
    [Fact]
    public void Test_WinningBidder_PaysSecondHighestPrice()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{100}),
            new("B", new List<int>{90, 80}),
            new("C", new List<int>{70})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(50, bidders);

        Assert.Equal("A", result.Winner);
        Assert.Equal(90, result.WinningPrice);
    }
    
    [Fact]
    public void Test_WinningPrice_IsReserve_WhenNoSecondHighestBid()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{100}),
            new("B", new List<int>{30, 40})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(50, bidders);

        Assert.Equal("A", result.Winner);
        Assert.Equal(50, result.WinningPrice);
    }
    
    [Fact]
    public void Test_TiedHighestBids_WinnerPaysSecondPrice()
    {
        var bidders = new List<Bidder>
        {
            new("A", new List<int>{100}),
            new("B", new List<int>{100}),
            new("C", new List<int>{90})
        };

        var service = new AuctionService();
        var result  = service.DetermineWinner(50, bidders);

        Assert.Equal("A", result.Winner);
        Assert.Equal(100, result.WinningPrice);
    }
}