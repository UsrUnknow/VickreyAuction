using Core.Interfaces;
using Core.Models;

namespace Core.Services;

public class AuctionService : IAuctionService
{
    public Result DetermineWinner(int reservePrice, List<Bidder> bidders)
    {
        // Récupérer toutes les enchères valides (>= prix de réserve)
        var validBids = bidders
                        .SelectMany(b => b.Bids, (bidder, bid) => new { Name = bidder.Name, Bid = bid })
                        .Where(b => b.Bid >= reservePrice) // Enchères >= prix de réserve
                        .OrderByDescending(b => b.Bid)     // Trier par enchère décroissante
                        .ToList();

        // Si aucune enchère valide, retourner "No Winner"
        if (!validBids.Any())
        {
            return new Result
            {
                Winner       = "No Winner",
                WinningPrice = reservePrice
            };
        }

        // Récupérer le meilleur candidat (premier dans la liste triée)
        var winner = validBids[0];

        return new Result
        {
            Winner       = winner.Name,
            WinningPrice = winner.Bid
        };
    }
}