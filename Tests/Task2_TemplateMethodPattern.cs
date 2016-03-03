// ReSharper disable InconsistentNaming
using DesignPatternsKata.Task2;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class Task2_TemplateMethodPattern
	{
		[Test]
		public void Should_apply_10_percent_tax_rate_in_uk()
		{
			var receiptGenerator = new ReceiptGenerator(Country.UnitedKingdom);

			var receipt = receiptGenerator.GetReceiptForItem();

			Assert.That(receipt, Is.EqualTo("Price: 10 Tax:0 Discount:0"));
		}
	}
}