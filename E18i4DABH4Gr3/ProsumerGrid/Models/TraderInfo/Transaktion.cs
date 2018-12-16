namespace E18i4DABH4Gr3.Models
{
    using Microsoft.Azure.Documents;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System;
    using System.Collections;

    public class Rootobject
    {
        public Transaktion Transaktion { get; set; }
    }

    public class Transaktion
    {
        [JsonProperty(PropertyName = "id")]
        public string TransaktionID { get; set; }

        [JsonProperty(PropertyName = "proconsumer")]
        public Proconsumerids[] ProconsumerIDs { get; set; }

        [JsonProperty(PropertyName = "pris")]
        public float Pris { get; set; }

        [JsonProperty(PropertyName = "transaktiontime")]
        public DateTime Transaktiontime { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public float TotalAmount { get; set; }
    }

    public class Proconsumerids
    {
        public int ProconsumerID { get; set; }
        public float Amount { get; set; }
    }


}