using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgusMediaInterviewTask.ModalClasses
{
    public class CalculateBillApiRequest
    {
        public List<OrderItems> Order { get; set; } = new List<OrderItems>();
        public string OrderTime { get; set; }
    }

    public class OrderItems
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
    }
}
