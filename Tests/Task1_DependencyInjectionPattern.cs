// ReSharper disable InconsistentNaming

using DesignPatternsKata.Task1;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class Task1_DependencyInjectionPattern
	{
		[Test]
		public void My_friend_should_say_hi()
		{
			var friend = new Friend();

			friend.SayHi();

			// An important object oriented design principle, which the Gang of Four recommend is:

			//    "Program to an interface, not an implementation"

			// Do this:
			// Make sure that your friend used their voice and said Hi! Replace this assertion with
			// one using the mock object below. In order to make the test pass, you'll need to update
			// the Friend class, so that it adheres to the principle above.

			Assert.Fail("I have no idea if my friend spoke or not");

			// Some questions for when you're done:
			// Where should we instantiate the objects which make up our application, if not at the
			// point where they are used?

			// How do we test that our application has been constructed and runs correctly?
		}

		class MockVoice
		{
			string _words;

			public void Say(string words)
			{
				_words = words;
			}

			public void AssertWasSpoken(string expectedWords)
			{
				Assert.That(_words, Is.EqualTo(expectedWords));
			}
		}
	}
}