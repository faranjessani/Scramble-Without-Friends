using System;
using System.Collections.Generic;

namespace ScrambleWithoutFriends
{
    public class ScrambleWithoutFriendsGame
    {
        private readonly IList<string> _possibleWords;
        private readonly ScrambleBoard _scrambleBoard;
        private readonly IScrambleSolver _scrambleSolver;
        private readonly ScrambleBoardGenerator _scrambleBoardGenerator;

        public ScrambleWithoutFriendsGame()
        {
            _scrambleBoardGenerator = new ScrambleBoardGenerator();
            _scrambleSolver = new ScrambleSolver();
            _scrambleBoard = new ScrambleBoard(4, 4, _scrambleBoardGenerator);
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