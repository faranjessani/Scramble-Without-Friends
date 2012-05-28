using System.Collections.Generic;
using System.Linq;

namespace ScrambleWithoutFriends
{
    internal class ScrambleSolver : IScrambleSolver
    {
        private readonly ScrambleDictionary _dictionary;
        private IList<string> _possibleWords;
        private ScrambleBoard _scrambleBoard;

        public ScrambleSolver()
        {
            _dictionary = new ScrambleDictionary(".\\Dictionary\\en_US.dic");
        }

        public IList<string> Solve(ScrambleBoard scrambleBoard)
        {
            _scrambleBoard = scrambleBoard;
            _possibleWords = new List<string>();

            for (int x = 0; x < _scrambleBoard.Width; x++)
                for (int y = 0; y < _scrambleBoard.Length; y++)
                    BuildWordsStartingAt(x, y);
            return _possibleWords;
        }

        private void BuildWordsStartingAt(int x, int y)
        {
            int nodeIndex = _scrambleBoard[x, y].ToNodeIndex();
            BuildWord(_dictionary.RootNode.ChildNodes[nodeIndex], x, y);
        }

        private void BuildWord(WordNode wordNode, int x, int y)
        {
            if (wordNode == null) return;
            if (wordNode.EndOfWord) _possibleWords.Add(wordNode.Word);

            IEnumerable<Move> possibleMoves = GetPossibleMoves(x, y);
            foreach (Move move in possibleMoves)
            {
                int nodeIndex = _scrambleBoard[move.X, move.Y].ToNodeIndex();
                BuildWord(wordNode.ChildNodes[nodeIndex], move.X, move.Y);
            }
        }

        private IEnumerable<Move> GetPossibleMoves(int x, int y)
        {
            var moves = new List<Move>();
            moves.Add(new Move(x - 1, y - 1));
            moves.Add(new Move(x - 1, y));
            moves.Add(new Move(x - 1, y + 1));
            moves.Add(new Move(x, y + 1));
            moves.Add(new Move(x + 1, y + 1));
            moves.Add(new Move(x + 1, y));
            moves.Add(new Move(x + 1, y - 1));
            moves.Add(new Move(x, y - 1));

            IEnumerable<Move> possibleMoves =
                moves.Where(a => a.X >= 0 && a.Y >= 0 && a.X < _scrambleBoard.Width && a.Y < _scrambleBoard.Length);
            return possibleMoves;
        }
    }
}