namespace Unit12
{
    public class Discount<T> where T : DiscountType
    {
        public static int DiscountOwnersCount = 0;
        public string Owner { get; }
        public float DiscountSize { get; }

        public Discount(string owner, T discountType)
        {
            Owner = owner;
            DiscountSize = discountType.Value;
        }
    }
}