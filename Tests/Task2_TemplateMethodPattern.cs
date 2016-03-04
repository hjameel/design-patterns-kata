// ReSharper disable InconsistentNaming

using DesignPatternsKata.Task2;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class Task2_TemplateMethodPattern
	{
		// Another of the Gang of Four's object oriented design principles is:

		//    "Encapsulate the concept that varies."

		// In this example the logic for determining the amount of tax to apply varies by country.
		// Encapsulate the logic for determining tax amount, and apply the template method design pattern
		// to allow it to be varied.
		// (Hint: You may need to modify some of the existing tests)

		// Something to think about once you've done this step:
		//   Where do we decide which concrete Receipt object to create?

		// (Scroll further down further to see the rest of this task)

		[Test]
		public void Should_apply_20_percent_tax_rate_in_UK()
		{
			var receipt = new Receipt(Country.UnitedKingdom);

			Assert.That(receipt.ForItemCosting(100), Is.EqualTo("Price: 120 Tax: 20"));
		}

		[TestCase(10, 11, 1)]
		[TestCase(11, 12.1, 1.1)]
		public void Should_apply_10_percent_tax_rate_in_US_for_items_10_dollars_and_over(
			decimal price, decimal priceAfterTax, decimal taxAmount)
		{
			var receipt = new Receipt(Country.UnitedStates);

			Assert.That(
				receipt.ForItemCosting(price),
				Is.EqualTo(string.Format("Price: {0} Tax: {1}", priceAfterTax, taxAmount)));
		}

		[Test]
		public void Should_apply_0_percent_tax_rate_in_US_for_items_under_10_dollars()
		{
			var receipt = new Receipt(Country.UnitedStates);

			Assert.That(receipt.ForItemCosting(9), Is.EqualTo("Price: 9 Tax: 0"));
		}

		[Test]
		public void Should_apply_15_percent_tax_rate_in_France()
		{
			// Once you've applied the template method pattern, fill in this test and add support for
			// French receipts, with a tax rate of 15 percent.

			// Something to think about once you've done this step:
			//   What modifications were required to add this new behaviour?
		}

		[Test]
		public void Should_optionally_apply_a_black_friday_discount_in_the_US()
		{
			// Black friday is coming up in the US!
			// Add a new receipt which applies a 20% discount to the price before tax on US receipts.

			// Switching this functionality on and off should be configurable in the same way as the
			// country.
		}

		[Test]
		public void Should_optionally_apply_a_black_friday_discount_in_the_UK()
		{
			// Black friday is less extreme in the UK -
			// Add a new receipt which applies a 20% discount if the price before tax is over 100 on
			// UK receipts.

			// Switching this functionality on and off should be configurable in the same way as the
			// country.

			// Something to think about once you've done this step:
			//   How many classes would be required to have a custom optional discount for each country?
		}
	}
}