using System;
using System.Collections.Generic;

namespace Unit12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var discount1 = new Discount<None>("John Smith", new None());
            Discount<None>.DiscountOwnersCount++;
            
            var discount2 = new Discount<FixedSum>("Jane Smith", new FixedSum(100f));
            Discount<FixedSum>.DiscountOwnersCount++;
            var discount3 = new Discount<FixedSum>("George Clark", new FixedSum(10.5f));
            Discount<FixedSum>.DiscountOwnersCount++;
            
            var discount4 = new Discount<Percent>("Irene Walker", new Percent(6f));
            Discount<Percent>.DiscountOwnersCount++;
            var discount5 = new Discount<Percent>("Adam Jensen", new Percent(19f));
            Discount<Percent>.DiscountOwnersCount++;

            Console.WriteLine($"Discount size: {discount1.DiscountSize}");
            Console.WriteLine($"Discount size: {discount2.DiscountSize}");
            Console.WriteLine($"Discount size: {discount3.DiscountSize}");
            Console.WriteLine($"Discount size: {discount4.DiscountSize}");
            Console.WriteLine($"Discount size: {discount5.DiscountSize}\n");
            
            Console.WriteLine($"Cards without discount: {Discount<None>.DiscountOwnersCount}");
            Console.WriteLine($"Cards with fixed discount sum: {Discount<FixedSum>.DiscountOwnersCount}");
            Console.WriteLine($"Cards with percent discount: {Discount<Percent>.DiscountOwnersCount}");
        }
    }
}