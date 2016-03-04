using System;

namespace DesignPatternsKata.Task2
{
	public static class App
	{
		// The entry point of this application
		public static void Main(string[] args)
		{
			// In a real application this might be set in a config file
			const Country configuredCountry = Country.UnitedKingdom;

			var receipt = new Receipt(configuredCountry);

			Console.WriteLine(receipt.ForItemCosting(100));
		}
	}

	public enum Country
	{
		UnitedKingdom,
		UnitedStates
	}

	public class Receipt
	{
		private readonly Country _salesCountry;

		public Receipt(Country salesCountry)
		{
			_salesCountry = salesCountry;
		}

		public string ForItemCosting(decimal price)
		{
			decimal taxAmount = 0;
			switch (_salesCountry)
			{
				case Country.UnitedKingdom:
					taxAmount = price * 0.2m;
					break;
				case Country.UnitedStates:
					if (price >= 10)
					{
						taxAmount = price * 0.1m;
					}
					break;
				default:
					throw new InvalidOperationException("Invalid country.");
			}

			var priceAfterTax = price + taxAmount;

			return string.Format("Price: {0:0.##} Tax: {1:0.##}", priceAfterTax, taxAmount);
		}
	}
}