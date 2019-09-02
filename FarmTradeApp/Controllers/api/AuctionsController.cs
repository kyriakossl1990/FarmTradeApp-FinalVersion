using AutoMapper;
using FarmTradeApp.Persistence;
using FarmTradeApp.Core.Dtos;
using FarmTradeApp.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace FarmTradeApp.Controllers.api
{
    [Authorize]
    public class AuctionsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public AuctionsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: /api/auction/
        public IHttpActionResult GetAuctions(int year)
        {
            return Ok(unitOfWork.Auctions.GetYearAuctions(year)
                        .Select(Mapper.Map<Auction, AuctionDto>));
        }

        [HttpPost]
        public IHttpActionResult Settle()
        {
            var expiredAuction = unitOfWork.Auctions.GetExpiredAuction();
            expiredAuction.Complete();

            var newAuction = Auction.Initialize(expiredAuction.AuctionEndDate);
            unitOfWork.Auctions.Add(newAuction);
            unitOfWork.Complete();

            return Ok();
        }
    }
}
