using System.Collections.Generic;
using System.Linq;

namespace ScrambleWithoutFriends
{
    internal class ScrambleSolver : IScrambleSolver
    {
        private IList<string> _possibleWords;
        private WordNode _rootNode;
        private ScrambleBoard _scrambleBoard;

        public ScrambleSolver(IScrambleDictionary scrambleDictionary)
        {
            ProcessDictionary(scrambleDictionary);
        }

        #region IScrambleSolver Members

        public IList<string> Solve(ScrambleBoard scrambleBoard)
        {
            _scrambleBoard = scrambleBoard;
            _possibleWords = new List<string>();

            for (int x = 0; x < _scrambleBoard.Width; x++)
                for (int y = 0; y < _scrambleBoard.Length; y++)
                    BuildWordsStartingAt(x, y);
            return _possibleWords;
        }

        #endregion

        private void ProcessDictionary(IScrambleDictionary dictionary)
        {
            _rootNode = new WordNode();
            foreach (string word in dictionary.WordList)
            {
                ProcessNode(_rootNode, new Stack<char>(word.Trim()), new Stack<char>());
            }
        }

        private void BuildWordsStartingAt(int x, int y)
        {
            int nodeIndex = _scrambleBoard[x, y].ToNodeIndex();
            BuildWord(_rootNode.ChildNodes[nodeIndex], x, y);
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
            var moves = new List<Move>
                            {
                                new Move(x - 1, y - 1),
                                new Move(x - 1, y),
                                new Move(x - 1, y + 1),
                                new Move(x, y + 1),
                                new Move(x + 1, y + 1),
                                new Move(x + 1, y),
                                new Move(x + 1, y - 1),
                                new Move(x, y - 1)
                            };

            IEnumerable<Move> possibleMoves =
                moves.Where(a => a.X >= 0 && a.Y >= 0 && a.X < _scrambleBoard.Width && a.Y < _scrambleBoard.Length);
            return possibleMoves;
        }

        private void ProcessNode(WordNode wordNode, Stack<char> remainingCharacters, Stack<char> processedCharacters)
        {
            if (remainingCharacters.Count == 0)
            {
                wordNode.EndOfWord = true;
                wordNode.Word = new string(processedCharacters.ToArray());
                return;
            }

            int nodeIndex;
            do
            {
                char character = remainingCharacters.Pop();
                processedCharacters.Push(character);

                nodeIndex = character.ToNodeIndex();
            } while (nodeIndex < wordNode.ChildNodes.GetLowerBound(0) ||
                     nodeIndex > wordNode.ChildNodes.GetUpperBound(0));

            if (wordNode.ChildNodes[nodeIndex] == null)
                wordNode.ChildNodes[nodeIndex] = new WordNode();

            ProcessNode(wordNode.ChildNodes[nodeIndex], remainingCharacters, processedCharacters);
        }
    }
}