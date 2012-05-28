using System.Collections.Generic;
using ScrambleWithoutFriends.Board_Generators;

namespace ScrambleWithoutFriends
{
    public class ScrambleWithoutFriendsGame
    {
        private readonly IList<string> _possibleWords;
        private readonly ScrambleBoard _scrambleBoard;
        private readonly IScrambleBoardGenerator _scrambleBoardGenerator;
        private readonly IScrambleSolver _scrambleSolver;

        public ScrambleWithoutFriendsGame()
        {
            _scrambleBoardGenerator = new VowelsInEachQuadrantBoardGenerator();
            _scrambleSolver = new ScrambleSolver();
            _scrambleBoard = new ScrambleBoard(Settings.DefaultSettings.Default.DefaultLength,
                                               Settings.DefaultSettings.Default.DefaultWidth,
                                               _scrambleBoardGenerator);
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