using System;
using ScrambleWithoutFriends;

namespace SampleApp
{
    internal class Program
    {
        private static void Main()
        {
            var app = new ScrambleWithoutFriendsGame();

            Console.WriteLine(app.Board);
            Console.WriteLine("Possible Words: {0}", app.PossibleWords.Count);
            Console.ReadLine();
        }
    }
}