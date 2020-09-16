using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HPFinanceAsignment.Models
{
    public class DeskOfCards
    {
        [JsonProperty("success")]
        public bool IfSuccess { get; set; }

        [JsonProperty("deck_id")]
        public string DeskId { get; set; }

        [JsonProperty("remaining")]
        public int RemainingNumber { get; set; }

        [JsonProperty("shuffled")]
        public bool IfShuffled { get; set; }
    }
}
