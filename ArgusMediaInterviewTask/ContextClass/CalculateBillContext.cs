using ArgusMediaInterviewTask.ApiFramework;
using ArgusMediaInterviewTask.Constants;
using ArgusMediaInterviewTask.ModalClasses;


namespace ArgusMediaInterviewTask.ContextClass
{
    public class CalculateBillContext
    {
        public double TotalBill { get; internal set; }
        public bool TimeGreaterThanSevenPm { get; internal set; } = false;
        public double FoodBill { get; internal set; }
        public double DrinksBill { get; internal set; }
        public double PartialBill { get; internal set; } = 0;
        public int NumberOfGuests { get; internal set; } = 0;
        public ApiResponseWithHeaders ApiResponseWithHeaders { get; internal set; }
        public CalculateBillApiRequest CalculateBillApiRequest { get; internal set; } = new CalculateBillApiRequest();
       
        public double CalculateBill()
        {
            FoodBill = 0;
            DrinksBill = 0;
            TotalBill = 0;
            foreach (var item in CalculateBillApiRequest.Order)
            {
                if (item.Item == "starters")
                {
                    FoodBill += item.Quantity * BillConstants.PriceOfStarter;
                }
                else if (item.Item == "mains")
                {
                    FoodBill += item.Quantity * BillConstants.PriceOfMains;
                }
                else if (item.Item == "drinks")
                {
                    CalculateDrinksBill(item.Quantity);
                }
            }

            TotalBill = FoodBill * (1 + BillConstants.SeriveChargeOnFood) + DrinksBill;

            return TotalBill + PartialBill;
        }
        public void AddItemsToBill(string item, int quantity)
        {
            var itemToUpdate = CalculateBillApiRequest.Order.FirstOrDefault(o => o.Item == item);
            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity += quantity;
            }
            else
            {
                CalculateBillApiRequest.Order.Add(new OrderItems { Item = item, Quantity = quantity });            
            }
        }
        public void CalculateDrinksBill(int quantityOfDrinks)
        {
            if (TimeGreaterThanSevenPm)
                DrinksBill += quantityOfDrinks * BillConstants.PriceOfDrinks;
            else
                //30% discount on drinks before 7pm
                DrinksBill += quantityOfDrinks * BillConstants.PriceOfDrinks * (1 - BillConstants.DrinksDiscountPercentageRate);
        }
        public void RemoveItems(string item, int quantity)
        {
            var itemToUpdate = CalculateBillApiRequest.Order.FirstOrDefault(o => o.Item == item);
            if (itemToUpdate.Quantity == 1 && quantity >= 1)
            {
                CalculateBillApiRequest?.Order.RemoveAll(o => o.Item == item);
            }
            else
            {
                itemToUpdate.Quantity -= quantity;
            }

        }
        public void SetTimeFlag(string orderTime)
        {
            DateTime actualOrderTime = DateTime.ParseExact(orderTime, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            DateTime DiscountEnddateTime = DateTime.ParseExact(BillConstants.DiscountEnddateTime, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            if (DateTime.Compare(actualOrderTime, DiscountEnddateTime) > 0)
            {
                TimeGreaterThanSevenPm = true;
            }
            
        }   
    }
}
