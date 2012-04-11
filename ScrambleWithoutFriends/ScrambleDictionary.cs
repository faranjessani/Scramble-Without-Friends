using System;
using System.Collections.Generic;
using System.IO;

namespace ScrambleWithoutFriends
{
    internal class ScrambleDictionary : IScrambleDictionary
    {
        public IList<string> WordList { get; private set; }
        public ScrambleDictionary(string dictionaryFile)
        {
            if(string.IsNullOrEmpty(dictionaryFile)) throw new ArgumentException();

            WordList = new List<string>();
            BuildDictionary(dictionaryFile);
        }

        public void BuildDictionary(string dictionaryFile)
        {
            using (var reader = new StreamReader(dictionaryFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    WordList.Add(line);
                }
            }
        }
    }
}