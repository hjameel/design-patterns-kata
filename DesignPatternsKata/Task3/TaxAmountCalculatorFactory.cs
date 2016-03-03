using System;

namespace DesignPatternsKata.Task3
{
	public class TaxAmountCalculatorFactory
	{
		public ITaxAmountCalculator CreateFor(Country salesCountry)
		{
			switch (salesCountry)
			{
				case Country.UnitedKingdom:
					return new UnitedKingdomTaxAmountCalculator();
				case Country.UnitedStates:
					return new UnitedStatesTaxAmountCalculator();
				default:
					throw new InvalidOperationException("Invalid country.");
			}
		}
	}
}