using AutoMapper;
using FarmTradeApp.Core.Dtos;
using FarmTradeApp.Core.Models.Market;
using FarmTradeApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FarmTradeApp.Controllers.api
{
    [Authorize]
    public class TradeMatchesController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public TradeMatchesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: /api/tradeMatches
        public IHttpActionResult GetTradeMatches(string userId = null)
        {
            var tradeMatchesQuery = unitOfWork.TradeMatches
                .GetUserTradeMatches();

            if (!String.IsNullOrWhiteSpace(userId))
            {
                tradeMatchesQuery = tradeMatchesQuery
                    .Where(e => e.BuyerEntry.UserId == userId || e.SellerEntry.UserId == userId);
            }

            var tradeMatchesDtos = tradeMatchesQuery
                        .OrderBy(m => m.Auction.AuctionEndDate)
                        .Select(Mapper.Map<TradeMatch, TradeMatchDto>)
                        .ToList();

            return Ok(tradeMatchesDtos);
        }
    }
}
