using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HPFinanceAsignment.Models
{
    class CardInDesk
    {
        [JsonProperty("image")]
        public string CardImage { get; set; }

        [JsonProperty("value")]
        public string CardValue { get; set; }

        [JsonProperty("suit")]
        public string CardSuit { get; set; }

        [JsonProperty("code")]
        public string CardCode { get; set; }
    }
}
