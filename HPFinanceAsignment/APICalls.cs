using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using HPFinanceAsignment.Models;

namespace HPFinanceAsignment
{
    
    class APICalls
    {
        public static DeskOfCards AddNewDeck(string apiURL, bool ifJokerNeeds, HttpClient myClient)
        {
            //Adding new desk of cards. If ifJokerNeeds parameter is true new desk will have 54 cards, overwise it will be 52 cards.
            HttpMethod apiMethod;
            apiMethod = HttpMethod.Get;
            apiURL += "new/";
            if (ifJokerNeeds)
            {
                apiURL += "?jokers_enabled=true";
            }
            HttpRequestMessage request = new HttpRequestMessage(apiMethod, apiURL);
            var response =  myClient.SendAsync(request).Result;
 
            var deskReturned = JsonConvert.DeserializeObject<DeskOfCards>(response.Content.ReadAsStringAsync().Result);
            return deskReturned;
        }

        public static DrawedCards DrawTheCard(string desk_id, int numberOfCards, string apiURL, HttpClient myClient)
        {
            //Draw requested numberOfCards from new or existing desk. If desk_id is empty then new desk of card will be created.
            if(string.IsNullOrEmpty(desk_id))
            {
                //create new desk and draw
                apiURL += "new/draw/?count=" + Convert.ToString(numberOfCards);
            }
            else
            {
                //call for existing desk. If id is incorrect it will return 500,
                //if number ecxeeded existing succcess will be false and number=0
                apiURL += desk_id + "/draw/?count=" + Convert.ToString(numberOfCards);
            }
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiURL);
            var response = myClient.SendAsync(request).Result;
            DrawedCards deskReturned = JsonConvert.DeserializeObject<DrawedCards>(response.Content.ReadAsStringAsync().Result);
            return deskReturned;
        }
    }
}
