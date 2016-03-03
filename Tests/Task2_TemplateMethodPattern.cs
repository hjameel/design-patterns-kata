// ReSharper disable InconsistentNaming

using System;
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
		// Do this:
		// Encapsulate the logic for determining tax amount, and apply the template method design pattern
		// to allow it to be varied.

		[Test]
		public void Should_apply_20_percent_tax_rate_in_UK()
		{
			var receiptGenerator = new ReceiptGenerator(Country.UnitedKingdom);

			var receipt = receiptGenerator.GetReceiptForItem(100);

			Assert.That(receipt, Is.EqualTo("Price: 120 Tax: 20"));
		}

		[TestCase(10, 11, 1)]
		[TestCase(11, 12.1, 1.1)]
		public void Should_apply_10_percent_tax_rate_in_US_for_items_10_dollars_and_over(
			decimal price, decimal priceAfterTax, decimal taxAmount)
		{
			var receiptGenerator = new ReceiptGenerator(Country.UnitedStates);

			var receipt = receiptGenerator.GetReceiptForItem(price);

			Assert.That(receipt, Is.EqualTo(string.Format("Price: {0} Tax: {1}", priceAfterTax, taxAmount)));
		}

		[Test]
		public void Should_apply_0_percent_tax_rate_in_US_for_items_under_10_dollars()
		{
			var receiptGenerator = new ReceiptGenerator(Country.UnitedStates);

			var receipt = receiptGenerator.GetReceiptForItem(9);

			Assert.That(receipt, Is.EqualTo("Price: 9 Tax: 0"));
		}

		[Test]
		public void Should_throw_exception_for_invalid_country_code()
		{
			const Country invalidCountry = (Country) 123;
			var receiptGenerator = new ReceiptGenerator(invalidCountry);

			Assert.That(() => receiptGenerator.GetReceiptForItem(10),
				Throws.TypeOf<InvalidOperationException>().With.Message.EqualTo("Invalid country."));
		}
	}
}