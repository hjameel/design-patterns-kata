// ReSharper disable InconsistentNaming

using DesignPatternsKata.Task3;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class Task3_StrategyAndAbstractFactoryPatterns
	{
		// As you saw in task 2, using the template method pattern when more than one concept is varying
		// can lead to a messy explosion of classes.

		// This leads us on to another of the Gang of Four's principles:

		//    "Favor object composition over class inheritance."

		// Read over the ReceiptGenerator code in Task3 folder. It now makes use of the strategy pattern
		// to encapsulate the variation in tax logic. Also note the use of a factory object to control
		// the creation of the tax strategy which gets used. Often one design pattern sets the context for
		// the use of another.

		// Do this:
		// Implement the functionality described in the tests below, this time using the strategy and
		// factory patterns.

		// Some questions to think about once you're done:
		// How does the strategy pattern avoid the issues you had with template method? What
		// advantages does template method have over strategy, if any?

		// How do the Gang of Four's design principles relate to the SOLID principles? Which do
		// you find more useful for thinking about the design of your code?

		[Test]
		public void Should_apply_15_percent_tax_rate_in_France()
		{
			// Add support for French receipts, with a tax rate of 15 percent.

			// Something to think about once you've done this step:
			//   What modifications were required to add this new behaviour?
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

			// Something to think about once you've done this step:
			//   How many classes would be required to have a custom optional discount for each country?
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