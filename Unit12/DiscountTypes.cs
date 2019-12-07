using System.Collections.Generic;

namespace Unit12
{
    public abstract class DiscountType
    {
        public float Value { get; protected set; }
    }
    
    public class Percent : DiscountType
    {
        public Percent(float percentValue)
        {
            Value = percentValue;
        }
    }
    
    public class FixedSum : DiscountType
    {
        public FixedSum(float sumValue)
        {
            Value = sumValue;
        }
    }
    
    public class None : DiscountType
    {
        public None()
        {
            Value = 0;
        }
    }
}