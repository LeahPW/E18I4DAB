using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProsumerGrid.Models.SmartGrid;
using E18i4DABH4Gr3.Models;

namespace ProsumerGrid.Services.Trade
{
    public class TradeService
    {
        private ApiClient<E18i4DABH4Gr3.Models.Trade, E18i4DABH4Gr3.Models.Trade> _tradeApi;

        public TradeService()
        {
            _tradeApi = new ApiClient<E18i4DABH4Gr3.Models.Trade, E18i4DABH4Gr3.Models.Trade>();
        }

        
    }
}