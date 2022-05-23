using System;
namespace CSHARP.GoodCode.Models
{
    public class CoffeeAttributes
    {
        public int Milk { get; set; }
        public bool Whitner { get; set; }
        public int Sugar { get; set; }
        public int Strength { get; set; }
        public SyrupEnum Syrup { get; set; }
        public ToppingEnum Topping { get; set; }
        public bool Sweetner { get; set; }
        public bool TakeAway { get; set; }
        public decimal VatRate { get; set; }
        public int BeanMix { get; set; }
    }
}
