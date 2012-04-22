using System;
using System.Collections.Generic;

namespace ScrambleWithoutFriends
{
    public class ScrambleWithoutFriendsGame
    {
        private readonly IList<string> _possibleWords;
        private readonly ScrambleBoard _scrambleBoard;
        private readonly IScrambleSolver _scrambleSolver;

        public ScrambleWithoutFriendsGame()
        {
            _scrambleBoard = new ScrambleBoard(4, 4, new StaticScrambleBoardGenerator());
            
            _scrambleSolver = new ScrambleSolver1(new ScrambleDictionary(".\\Dictionary\\en_US.dic"));
            _possibleWords = _scrambleSolver.Solve(_scrambleBoard);
        }

        public IList<string> PossibleWords
        {
            get { return _possibleWords; }
        }

        public ScrambleBoard Board
        {
            get { return _scrambleBoard; }
        }
    }
}