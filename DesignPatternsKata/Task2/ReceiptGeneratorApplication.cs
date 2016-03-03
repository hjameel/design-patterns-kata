namespace DesignPatternsKata.Task2
{
	public class ReceiptGenerator
	{
		private readonly Country _salesCountry;

		public ReceiptGenerator(Country salesCountry)
		{
			_salesCountry = salesCountry;
		}

		public string GetReceiptForItem()
		{
			return "Price: 10 Tax:0 Discount:0";
		}
	}

	public enum Country
	{
		UnitedKingdom
	}
}