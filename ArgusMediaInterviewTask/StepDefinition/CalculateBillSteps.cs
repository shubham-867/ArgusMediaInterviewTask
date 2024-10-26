using ArgusMediaInterviewTask.ApiFramework;
using ArgusMediaInterviewTask.Constants;
using ArgusMediaInterviewTask.ContextClass;
using ArgusMediaInterviewTask.JsonPayload;
using ArgusMediaInterviewTask.ModalClasses;
using ArgusMediaInterviewTask.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Globalization;
using TechTalk.SpecFlow;

namespace ArgusMediaInterviewTask.StepDefinition
{
    [Binding]
    public sealed class CalculateBillSteps
    {
        private readonly CalculateBillContext _calculateBillContext;
        private readonly ApiClient _apiClient;
        private readonly ConfigManager _configManager;
        public CalculateBillSteps(CalculateBillContext CalculateBillContext, ApiClient apiClient, ConfigManager config)
        {
            _calculateBillContext = CalculateBillContext;
            _apiClient = apiClient;
            _configManager = config;
        }

        [Given(@"a group of (.*) people is in a restaurant")]
        public void GivenAGroupOfPeopleIsInARestaurant(int numberOfGuests)
        {
            _calculateBillContext.NumberOfGuests = numberOfGuests;
        }

        [When(@"they order")]
        public void WhenTheyOrder(Table table)
        {
            foreach (var row in table.Rows)
            {
                _calculateBillContext.AddItemsToBill(row["Item"], int.Parse(row["Quantity"]));
            }
        }

        [When(@"the order is placed at ""([^""]*)""")]
        public void WhenTheOrderIsPlacedAt(string orderTime)
        {            
            _calculateBillContext.CalculateBillApiRequest.Time = orderTime;
            _calculateBillContext.SetTimeFlag(_calculateBillContext.CalculateBillApiRequest.Time);            
        }

        [Then(@"The bill should be as per the calculation ""([^""]*)""")]
        public void ThenTheBillShouldBeAsPerTheCalculation(string actualTotalBill)
        {
            // API call to get the actual bill amount
            // commenting the below code as we don't have actual API
            #region APICall
            //var requestPayload = JsonConvert.SerializeObject(_calculateBillContext.CalculateBillApiRequest);
            //_apiClient.apiUrl = _configManager.GetConfiguration("CalculateBillApi");
            //_apiClient.AddRequestbody(requestPayload);
            //_calculateBillContext.ApiResponseWithHeaders = _apiClient.PostAsync();
            //var TotalBill = JsonConvert.DeserializeObject<CalculateBillApiResponse>(_calculateBillContext.ApiResponseWithHeaders.Content);
            #endregion

            #region Assert
            //Assert the calculated bill with the actual bill
            // The "TotalBill" fetched from the above API call is used to assert the calculated bill
            //Since we don't have actual API, I've fetched "actualTotalBill" from the feature file. Other wise feature should not not provide the actual bill amount.
            Assert.That(Math.Round(_calculateBillContext.CalculateBill()), Is.EqualTo(Math.Round(double.Parse(actualTotalBill))));
            Console.WriteLine($"TotalNumberOfGuests: {_calculateBillContext.NumberOfGuests}");
            #endregion
        }
        [Then(@"status code should be (.*)")]
        public void ThenStatusCodeShouldBe(int statusCode)
        {
            // commenting the below code as we don't have actual API to get the status code.
           // Assert.That((int)_calculateBillContext.ApiResponseWithHeaders.StatusCode, Is.EqualTo(statusCode));
        }

        [When(@"(.*) more people join the group")]
        public void WhenMorePeopleJoinTheGroup(int numberOfguestsAdded)
        {
            _calculateBillContext.NumberOfGuests += numberOfguestsAdded;
        }

        [When(@"(.*) member cancels thier order and leaves the group")]
        public void WhenMemberCancelsThierOrderAndLeavesTheGroup(int numberOfGuestsLeft)
        {
            _calculateBillContext.NumberOfGuests -= numberOfGuestsLeft;
        }
        [When(@"following items are added in the order")]
        public void WhenFollowingItemsAreAddedInTheOrder(Table table)
        {
            _calculateBillContext.PartialBill = _calculateBillContext.TotalBill;
           _calculateBillContext.CalculateBillApiRequest.Order.Clear();
            foreach (var row in table.Rows)
            {
                _calculateBillContext.AddItemsToBill(row["Item"], int.Parse(row["Quantity"]));
            }
        }

        [When(@"following items are removed from the order")]
        public void WhenFollowingItemsAreRemovedFromTheOrder(Table table)
        {
            foreach (var row in table.Rows)
            {
                _calculateBillContext.RemoveItems(row["Item"], int.Parse(row["Quantity"]));
            }
        }
    }
}