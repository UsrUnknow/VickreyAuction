using Core.Models;

namespace Core.Interfaces;

public interface IAuctionService
{
    Result DetermineWinner(int reservePrice, List<Bidder> bidders);
}