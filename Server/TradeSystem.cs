
using System;

namespace EVE.AI
{
    public class TradeSystem
    {
        public string Planet { get; set; }
        public int Metal { get; set; }
        public int Fuel { get; set; }

        public TradeSystem(string planet, int metal, int fuel)
        {
            Planet = planet;
            Metal = metal;
            Fuel = fuel;
        }

        public void ExecuteTrade(string resource, int amount)
        {
            Console.WriteLine($"{amount} units of {resource} traded on {Planet}.");
        }
    }
}
