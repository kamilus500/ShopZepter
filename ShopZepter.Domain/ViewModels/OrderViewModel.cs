using ShopZepter.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ShopZepter.Domain.ViewModels
{
    public class OrderViewModel
    {
        public string Name { get; set; }
        public decimal Gross { get; set; }
        public decimal Net { get; set; }
        public int Count { get; set; }

        [Display(Name = "Type of payment")]
        public PayType Type { get; set; }
        public int Sum { get; set; }
        public string Adress { get; set; }
    }
}
