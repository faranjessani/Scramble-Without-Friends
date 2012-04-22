using System.Collections.Generic;

namespace ScrambleWithoutFriends
{
    public abstract class ScrambleSolverBase : IScrambleSolver
    {
        protected readonly IScrambleDictionary _scrambleDictionary;

        public ScrambleSolverBase(IScrambleDictionary scrambleDictionary)
        {
            _scrambleDictionary = scrambleDictionary;
        }

        public abstract IList<string> Solve(ScrambleBoard scrambleBoard);
    }
}