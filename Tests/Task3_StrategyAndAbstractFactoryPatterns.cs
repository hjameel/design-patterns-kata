// ReSharper disable InconsistentNaming

using System;
using DesignPatternsKata.Task3;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class Task3_StrategyAndAbstractFactoryPatterns
	{
		// Another of the Gang of Four's object oriented design principles is:

		//    "Encapsulate the concept that varies."

		// In this example the logic for determining the amount of tax to apply varies by country.
		// Encapsulate the logic for determining tax amount, and apply the template method design pattern
		// to allow it to be varied.

		// Question: Where do we decide which concrete receipt generator to create?

		[Test]
		public void Should_apply_15_percent_tax_rate_in_France()
		{
			// Once you've applied the template method pattern, fill in the test and add support for
			// French receipts, with a tax rate of 15 percent.

			// Question: What modifications were required to add this new behaviour?
		}

		[Test]
		public void Should_optionally_apply_a_black_friday_discount_in_the_US()
		{
			// Black friday is coming up in the US!
			// Add functionality to apply a 20% discount to the price before tax on US receipts.

			// Switching this functionality on and off should be configurable in the same way as the
			// country.
		}

		[Test]
		public void Should_optionally_apply_a_black_friday_discount_in_the_UK()
		{
			// Black friday is less extreme in the UK -
			// Add functionality to apply a 20% discount if the price before tax is over 100 on UK receipts.

			// Switching this functionality on and off should be configurable in the same way as the
			// country.

			// Question: How many classes would be required to have a custom optional discount for
			// each country?
		}

		[Test]
		public void Should_apply_20_percent_tax_rate_in_UK()
		{
			var receiptGenerator = new ReceiptGenerator(new UnitedKingdomTaxAmountCalculator());

			var receipt = receiptGenerator.GetReceiptForItem(100);

			Assert.That(receipt, Is.EqualTo("Price: 120 Tax: 20"));
		}

		[TestCase(10, 11, 1)]
		[TestCase(11, 12.1, 1.1)]
		public void Should_apply_10_percent_tax_rate_in_US_for_items_10_dollars_and_over(
			decimal price, decimal priceAfterTax, decimal taxAmount)
		{
			var receiptGenerator = new ReceiptGenerator(new UnitedStatesTaxAmountCalculator());

			var receipt = receiptGenerator.GetReceiptForItem(price);

			Assert.That(receipt, Is.EqualTo(string.Format("Price: {0} Tax: {1}", priceAfterTax, taxAmount)));
		}

		[Test]
		public void Should_apply_0_percent_tax_rate_in_US_for_items_under_10_dollars()
		{
			var receiptGenerator = new ReceiptGenerator(new UnitedStatesTaxAmountCalculator());

			var receipt = receiptGenerator.GetReceiptForItem(9);

			Assert.That(receipt, Is.EqualTo("Price: 9 Tax: 0"));
		}
	}
}