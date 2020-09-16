using NUnit.Framework;
using System.Net.Http;

namespace HPFinanceAsignment
{
    public class Tests
    {
        private const string CardApiUrl = "https://deckofcardsapi.com/api/deck/";
        HttpClient myClient = new HttpClient();

        [TestCase(false, true, 52, TestName = "Successfully Create New Desk Wihtout Joker")]
        [TestCase(true, true, 54, TestName ="Successfully Create New Desk With Joker")]
        public void VerifyAddingNewDescOfCards(bool ifJoker, bool ifSuccess, int numberOfCards)
        {
            var result = APICalls.AddNewDeck(CardApiUrl, ifJoker, myClient);
            Assert.AreEqual(result.IfSuccess, ifSuccess);
            Assert.AreEqual(result.RemainingNumber, numberOfCards);
        }

        [TestCase(true, 5, 47, TestName="Draw 5 Cards From New Desk Without Joker")]
        [TestCase(false, 53, 0, TestName = "Draw 53 Cards From New Desk Without Joker")]
        [TestCase(true, 0, 52, TestName = "Draw 0 Cards From New Desk Without Joker")]
        public void DrawCardsFromNewDesk(bool ifSuccess, int numberOfCards, int remainingNumber)
        {
            var result = APICalls.DrawTheCard("", numberOfCards, CardApiUrl,  myClient);
            Assert.AreEqual(result.IfSuccess, ifSuccess);
            Assert.AreEqual(result.RemainingNumber, remainingNumber);
        }

        [TestCase(true, true, 5, 49, TestName = "Draw 5 Cards From Desk With Joker")]
        [TestCase(false, false, 100, 0, TestName = "Draw 100 Cards From Desk Without Joker")]
        public void DrawCardFromExistingDesk(bool ifJoker, bool ifSuccess, int numberOfCards, int remainingNumber)
        {
            var result = APICalls.AddNewDeck(CardApiUrl, ifJoker, myClient);
            string cardDesk_id = result.DeskId;
            var final_result = APICalls.DrawTheCard(cardDesk_id, numberOfCards, CardApiUrl, myClient);
            Assert.AreEqual(final_result.IfSuccess, ifSuccess);
            Assert.AreEqual(final_result.RemainingNumber, remainingNumber);
        }
    }
}