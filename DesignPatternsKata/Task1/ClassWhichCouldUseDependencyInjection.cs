using System;

namespace DesignPatternsKata
{
	public static class App
	{
		public static void Main()
		{
			new Friend().SayHi();
		}
	}

	public class Friend
	{
		public void SayHi()
		{
			// By instantiating an instance of Voice here, we've created tight coupling between
			// Friend and the FriendsVoice implementation.
			new FriendsVoice().Say("Hi!");
		}
	}

	public class FriendsVoice
	{
		public void Say(string words)
		{
			Console.WriteLine(words);
		}
	}
}

