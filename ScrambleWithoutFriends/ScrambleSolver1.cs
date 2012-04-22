using System.Collections.Generic;
using System.Linq;
using ScrambleWithoutFriends;

namespace ScrambleWithoutFriends
{
    public class ScrambleSolver1 : ScrambleSolverBase
    {
        private static List<string> _possibleWords = new List<string>();
        private ScrambleBoard _scrambleBoard;

        public ScrambleSolver1(IScrambleDictionary scrambleDictionary) : base(scrambleDictionary)
        {
        }

        public override IList<string> Solve(ScrambleBoard scrambleBoard)
        {
            _scrambleBoard = scrambleBoard;
            for (int x = 0; x < scrambleBoard.Width; x++)
                for (int y = 0; y < scrambleBoard.Length; y++)
                    BuildWordList(new Move1(x, y, null));

            return _possibleWords;
        }

        private void BuildWordList(Move1 move)
        {
            string word = global::Extensions.GetWord((Move1)move, _scrambleBoard);

            if (word.Length > 2 && _scrambleDictionary.WordList.Contains(word) && !_possibleWords.Contains(word)) _possibleWords.Add(word);
            if (_scrambleDictionary.WordList.Any(w => w.StartsWith(word)))
            {
                IEnumerable<Move1> availableMoves = GetPossibleMoves(move);
                foreach (var availableMove in availableMoves)
                {
                    BuildWordList(availableMove);
                }
            }
        }

        private IEnumerable<Move1> GetPossibleMoves(Move1 previousMove)
        {
            int x = previousMove.X;
            int y = previousMove.Y;
            var moves = new List<Move1>
                            {
                                new Move1(x - 1, y - 1, previousMove),
                                new Move1(x - 1, y, previousMove),
                                new Move1(x - 1, y + 1, previousMove),
                                new Move1(x, y + 1, previousMove),
                                new Move1(x + 1, y + 1, previousMove),
                                new Move1(x + 1, y, previousMove),
                                new Move1(x + 1, y - 1, previousMove),
                                new Move1(x, y - 1, previousMove)
                            };

            var possibleMoves = from move in moves
                                where !previousMove.Contains(move)
                                      && move.X >= 0 && move.Y >= 0
                                      && move.X <= _scrambleBoard.Width - 1
                                      && move.Y <= _scrambleBoard.Length - 1
                                select move;
            return possibleMoves;
        }
    }
}

internal class Move1
{
    public int X, Y;

    public Move1(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Move1(int x, int y, Move1 previous)
    {
        X = x;
        Y = y;
        Previous = previous;
    }

    public Move1 Previous { get; set; }

    public override bool Equals(object obj)
    {
        var move = obj as Move1;
        if (move == null) return false;
        if (move.X == X && move.Y == Y) return true;

        return false;
    }

    public override int GetHashCode()
    {
        return X + Y;
    }
}

internal static class Extensions
{
    public static string GetWord(this Move1 move1, ScrambleBoard board)
    {
        if (move1.Previous == null) return string.Empty;

        return board[move1.X, move1.Y] + move1.Previous.GetWord(board);
    }

    public static bool Contains(this Move1 currentMove1, Move1 newMove1)
    {
        if (newMove1 == null) return false;
        if (currentMove1.Previous == null) return currentMove1.Equals(newMove1);

        return currentMove1.Previous.Contains(newMove1);
    }
}