using AutoMapper;
using FarmTradeApp.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using FarmTradeApp.Core.Models.Market;
using FarmTradeApp.Core.Dtos;
using Microsoft.AspNet.Identity;

namespace FarmTradeApp.Controllers.api
{
    [Authorize]
    public class MarketEntriesController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public MarketEntriesController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: /api/marketEntry
        public IHttpActionResult GetMarketEntries(int? auctionId = null, string type = null, string userId = null)
        {
            var marketEntriesQuery = unitOfWork.MarketEntries
                .GetUserMarketEntriesWithFinalProduct();

            if (auctionId != null)
            {
                marketEntriesQuery = marketEntriesQuery
                    .Where(m => m.AuctionId == auctionId);
            }

            if (!String.IsNullOrWhiteSpace(type))
            {
                if (type == "supply")
                {
                    marketEntriesQuery = marketEntriesQuery
                        .Where(m => m.EntryType == EntryType.Supply);
                }
                else if (type == "demand")
                {
                    marketEntriesQuery = marketEntriesQuery
                            .Where(m => m.EntryType == EntryType.Demand);
                }
            }

            if (!String.IsNullOrWhiteSpace(userId))
            {
                marketEntriesQuery = marketEntriesQuery
                    .Where(e => e.UserId == userId);
            }

            var marketEntriesDtos = marketEntriesQuery
                        .OrderBy(m => m.EntryDate)
                        .Select(Mapper.Map<MarketEntry, MarketEntryDto>)
                        .ToList();

            int counter = 0;
            foreach (var marketEntryDto in marketEntriesDtos)
            {
                counter++;
                marketEntryDto.SetTableId(counter);
            }

            return Ok(marketEntriesDtos);
        }

        // GET: /api/marketEntry/1
        public IHttpActionResult GetMarketEntry(int id)
        {
            var marketEntry = unitOfWork.MarketEntries.GetFullMarketEntry(id);

            if (marketEntry == null)
                return NotFound();

            return Ok(Mapper.Map<MarketEntry, MarketEntryDto>(marketEntry));
        }

        // POST: /api/marketEntry
        [HttpPost]
        public IHttpActionResult PostMarketEntry(MarketEntryDto marketEntryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var marketEntry = Mapper.Map<MarketEntryDto, MarketEntry>(marketEntryDto);

            unitOfWork.MarketEntries.Add(marketEntry);
            unitOfWork.Complete();

            return Created(new Uri(Request.RequestUri + "/" + marketEntry.Id), marketEntryDto);
        }

        // PUT: /api/marketEntry/1
        [HttpPut]
        public IHttpActionResult UpdateMarketEntry(int id, MarketEntryDto marketEntryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var marketEntryInDB = unitOfWork.MarketEntries.GetMarketEntry(id);

            if (marketEntryInDB == null)
                return NotFound();

            Mapper.Map(marketEntryDto, marketEntryInDB);

            unitOfWork.Complete();

            return Ok();
        }

        // DELETE: Remove
        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var marketEntry = unitOfWork.MarketEntries.GetMarketEntry(id);

            if (marketEntry.IsRemoved || marketEntry == null)
                return NotFound();

            if (marketEntry.UserId != User.Identity.GetUserId())
                return Unauthorized();

            marketEntry.Remove();

            unitOfWork.Complete();
            return Ok();
        }
    }
}
