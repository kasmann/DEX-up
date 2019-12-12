using System;
using System.Collections.Generic;

namespace Unit12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //дженерики в целом
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
            Console.WriteLine($"Cards with percent discount: {Discount<Percent>.DiscountOwnersCount}\n");
            
            //уникальная коллекция
            try
            {
                var unique = new UniqueCollection<string>(new[] {"first", "second", "third"});
                unique.Add("second");
            }
            catch (NonUniqueValue ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var unique2 = new UniqueCollection<string>(new[] {"first", "second", "second"});
            }
            catch (NonUniqueValue ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                var perc10 = new Percent(10);
                var perc15 = new Percent(15);
                var fix100 = new FixedSum(100);
                var none = new None();
                var unique3 = new UniqueCollection<DiscountType>(new DiscountType[]{perc10, perc15, fix100, none});
                unique3.Add(perc10);
            }
            catch (NonUniqueValue ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}