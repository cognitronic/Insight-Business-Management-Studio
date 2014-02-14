using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Insight.Core.Domain;

namespace Insight.Core.Interfaces
{
    public interface IOrder : IItem
    {
        int ID { get; set; }
        string Description { get; set; }
        int OrderStatusID { get; set; }
        int AccountID { get; set; }
        DateTime OrderDate { get; set; }
        bool IsTaxExempt { get; set; }
        int EnteredBy { get; set; }
        int ChangedBy { get; set; }
        string Notes { get; set; }
        int AccountContactID { get; set; }
        int RequestedBy { get; set; }
        string ClientPO { get; set; }
        decimal TotalCost { get; set; }
        decimal TotalSale { get; set; }
        decimal TotalProfit { get; set; }
        string Title { get; set; }
        Account Account { get; set; }
        Contact Contact { get; set; }
        OrderStatus Status { get; set; }
    }
}
