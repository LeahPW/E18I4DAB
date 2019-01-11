using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using ProsumerGrid.Models.Prosumer;

namespace ProsumerGrid.Services.Prosumer
{
    public class ProsumerService
    {
        private ApiClient<Models.Prosumer.Prosumer, ProsumerDTO> _prosumerApi;

        public ProsumerService()
        {
            _prosumerApi = new ApiClient<Models.Prosumer.Prosumer, ProsumerDTO>();
        }

        public List<ProsumerDTO> GetAllProsumers()
        {
            List<ProsumerDTO> prosumers;
            try
            {
                HttpResponseMessage response = _prosumerApi.GetResponse("prosumers");
                response.EnsureSuccessStatusCode();
                prosumers = response.Content.ReadAsAsync<List<ProsumerDTO>>().Result;

            }
            catch (Exception)
            {
                throw;
            }

            return prosumers;
        }
    }
}