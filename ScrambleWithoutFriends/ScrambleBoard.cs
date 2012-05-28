using System;
using System.Text;

namespace ScrambleWithoutFriends
{
    public class ScrambleBoard
    {
        private readonly char[,] _board;

        public ScrambleBoard(int length, int width, IScrambleBoardGenerator scrambleBoardGenerator)
        {
            if (length <= 0 || width <= 0) throw new ArgumentOutOfRangeException();

            Length = length;
            Width = width;
            _board = new char[width,length];

            scrambleBoardGenerator.PopulateBoard(this);
        }

        public int Length { get; private set; }
        public int Width { get; private set; }

        internal virtual char this[int i, int j]
        {
            get { return _board[i, j]; }
            set { _board[i, j] = value; }
        }

        public override string ToString()
        {
            var boardAsString = new StringBuilder();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    boardAsString.Append(_board[i, j] + " ");
                }
                boardAsString.Append(new[] {'\r', '\n'});
            }

            return boardAsString.ToString();
        }
    }
}