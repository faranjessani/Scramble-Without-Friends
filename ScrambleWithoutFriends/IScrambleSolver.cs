using System.Collections.Generic;

namespace ScrambleWithoutFriends
{
    internal interface IScrambleSolver
    {
        IList<string> Solve(ScrambleBoard scrambleBoard);
    }
}