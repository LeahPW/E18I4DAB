using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using ProsumerGrid.Models.SmartGrid;
using E18i4DABH4Gr3.Models;
using ProsumerGrid.Models.Prosumer;
using ProsumerGrid.Models.Trade;

namespace ProsumerGrid.Services.Trade
{
    public class TradeService
    {
        private ApiClient<E18i4DABH4Gr3.Models.Trade, E18i4DABH4Gr3.Models.Trade> _tradeApi;

        public TradeService()
        {
            _tradeApi = new ApiClient<E18i4DABH4Gr3.Models.Trade, E18i4DABH4Gr3.Models.Trade>();
        }

        public List<TradeDTO> GetAll()
        {
            List<TradeDTO> trades;
            try
            {
                HttpResponseMessage response = _tradeApi.GetResponse("Trade/all");
                response.EnsureSuccessStatusCode();
                trades = response.Content.ReadAsAsync<List<TradeDTO>>().Result;

            }
            catch (Exception)
            {
                throw;
            }

            return trades;
        }

        public List<TradeDTO> GetPlanned()
        {
            List<TradeDTO> trades;
            try
            {
                HttpResponseMessage response = _tradeApi.GetResponse("Trade/planned");
                response.EnsureSuccessStatusCode();
                trades = response.Content.ReadAsAsync<List<TradeDTO>>().Result;

            }
            catch (Exception)
            {
                throw;
            }

            return trades;
        }

        public List<TradeDTO> GetCurrent()
        {
            List<TradeDTO> trades;
            try
            {
                HttpResponseMessage response = _tradeApi.GetResponse("Trade/current");
                response.EnsureSuccessStatusCode();
                trades = response.Content.ReadAsAsync<List<TradeDTO>>().Result;

            }
            catch (Exception)
            {
                throw;
            }

            return trades;
        }

        public List<TradeDTO> GetArchived()
        {
            List<TradeDTO> trades;
            try
            {
                HttpResponseMessage response = _tradeApi.GetResponse("Trade/archived");
                response.EnsureSuccessStatusCode();
                trades = response.Content.ReadAsAsync<List<TradeDTO>>().Result;
            }
            catch (Exception)
            {
                throw;
            }

            return trades;
        }

        public HttpResponseMessage AddTrade(E18i4DABH4Gr3.Models.Trade trade)
        {
            HttpResponseMessage response;
            try
            {
                response = _tradeApi.Post("trades", trade);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                throw;
            }

            return response;
        }
    }
}