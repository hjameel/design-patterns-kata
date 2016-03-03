namespace DesignPatternsKata.Task3
{
	public interface ITaxAmountCalculator
	{
		decimal CalculateTaxAmount(decimal price);
	}

	public class UnitedStatesTaxAmountCalculator : ITaxAmountCalculator
	{
		public decimal CalculateTaxAmount(decimal price)
		{
			decimal taxAmount = 0;
			if (price >= 10)
			{
				taxAmount = price*0.1m;
			}
			return taxAmount;
		}
	}

	public class UnitedKingdomTaxAmountCalculator : ITaxAmountCalculator
	{
		public decimal CalculateTaxAmount(decimal price)
		{
			return price*0.2m;
		}
	}
}