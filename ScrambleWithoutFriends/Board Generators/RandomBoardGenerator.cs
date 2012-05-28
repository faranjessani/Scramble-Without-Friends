using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScrambleWithoutFriends
{
    public class RandomBoardGenerator : IScrambleBoardGenerator
    {
        public void PopulateBoard(ScrambleBoard scrambleBoard)
        {
            var rand = new Random();

            for (int i = 0; i < scrambleBoard.Width; i++)
            {
                for (int j = 0; j < scrambleBoard.Length; j++)
                {
                    scrambleBoard[i, j] = (char)('a' + rand.Next(0, 26));
                }
            }
        }
    }
}
