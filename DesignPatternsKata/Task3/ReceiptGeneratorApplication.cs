using System;

namespace DesignPatternsKata.Task3
{
	public static class App
	{
		// The entry point of this application
		public static void Main(string[] args)
		{
			// In a real application this might be set in a config file
			const Country configuredCountry = Country.UnitedKingdom;

			var taxAmountCalculator = new TaxAmountCalculatorFactory().CreateFor(configuredCountry);
			var receipt = new Receipt(taxAmountCalculator);

			Console.WriteLine(receipt.ForItemCosting(100));
		}
	}

	public class Receipt
	{
		private readonly ITaxAmountCalculator _taxAmountCalculator;

		public Receipt(ITaxAmountCalculator taxAmountCalculator)
		{
			_taxAmountCalculator = taxAmountCalculator;
		}

		public string ForItemCosting(decimal price)
		{
			var taxAmount = _taxAmountCalculator.CalculateTaxAmount(price);

			var priceAfterTax = price + taxAmount;

			return string.Format("Price: {0:0.##} Tax: {1:0.##}", priceAfterTax, taxAmount);
		}
	}
}