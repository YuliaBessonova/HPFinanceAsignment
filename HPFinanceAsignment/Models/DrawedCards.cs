using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HPFinanceAsignment.Models
{
    class DrawedCards
    {
        [JsonProperty("success")]
        public bool IfSuccess { get; set; }

        [JsonProperty("cards")]
        public List<CardInDesk> CardInDraw { get; set; }

        [JsonProperty("deck_id")]
        public string DeskId { get; set; }

        [JsonProperty("remaining")]
        public int RemainingNumber { get; set; }
    }
}
