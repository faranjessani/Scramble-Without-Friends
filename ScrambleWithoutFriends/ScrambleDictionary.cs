using System;
using System.Collections.Generic;
using System.IO;

namespace ScrambleWithoutFriends
{
    internal class ScrambleDictionary : IScrambleDictionary
    {
        public WordNode RootNode { get; private set; }

        public ScrambleDictionary(string dictionaryFile)
        {
            if(string.IsNullOrEmpty(dictionaryFile)) throw new ArgumentException();

            BuildDictionary(dictionaryFile);
        }

        public void BuildDictionary(string dictionaryFile)
        {
            RootNode = new WordNode();

            using (var reader = new StreamReader(dictionaryFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ProcessNode(RootNode, new Stack<char>(line.Trim()), new Stack<char>());
                }
            }
        }

        internal void ProcessNode(WordNode wordNode, Stack<char> remainingCharacters, Stack<char> processedCharacters)
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
            } while (nodeIndex < wordNode.ChildNodes.GetLowerBound(0) || nodeIndex > wordNode.ChildNodes.GetUpperBound(0));

            if (wordNode.ChildNodes[nodeIndex] == null)
                wordNode.ChildNodes[nodeIndex] = new WordNode();

            ProcessNode(wordNode.ChildNodes[nodeIndex], remainingCharacters, processedCharacters);
        }
    }
}