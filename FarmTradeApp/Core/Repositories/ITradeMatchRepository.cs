using FarmTradeApp.Core.Models.Market;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmTradeApp.Core.Repositories
{
    public interface ITradeMatchRepository
    {
        IEnumerable<TradeMatch> GetUserTradeMatches();
    }
}
