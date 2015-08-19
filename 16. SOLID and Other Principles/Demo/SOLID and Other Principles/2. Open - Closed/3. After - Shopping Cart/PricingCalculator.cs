namespace OpenClosedShoppingCartAfter
{
    using System.Collections.Generic;
    using System.Linq;

    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<IPriceRule> pricingRules;

        public PricingCalculator()
        {
            this.pricingRules = new List<IPriceRule>
                                    {
                                        new EachPriceRule(),
                                        new PerGramPriceRule(),
                                        new SpecialPriceRule(),
                                        new Buy4GetOneFree()
                                    };
        }

        public decimal CalculatePrice(OrderItem item)
        {
            return this.pricingRules.First(r => r.IsMatch(item)).CalculatePrice(item);
        }
    }
}