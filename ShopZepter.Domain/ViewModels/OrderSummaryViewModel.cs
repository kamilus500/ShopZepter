
using ShopZepter.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShopZepter.Domain.ViewModels
{
    public class OrderSummaryViewModel
    {
        public int Count { get; set; }

        [Display(Name = "Total Gross")]
        public decimal TotalGross { get; set; }

        [Display(Name = "Type of payment")]
        public PayType Type { get; set; }
    }
}
