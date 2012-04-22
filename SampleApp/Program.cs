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
            //foreach(var word in app.PossibleWords) Console.WriteLine(word);
            Console.WriteLine("Possible Words: {0}", app.PossibleWords.Count);
            //Console.ReadLine();
        }
    }
}