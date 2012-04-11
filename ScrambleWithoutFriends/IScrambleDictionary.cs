using System.Collections.Generic;

namespace ScrambleWithoutFriends
{
    internal interface IScrambleDictionary
    {
        IList<string> WordList { get; }
        void BuildDictionary(string dictionaryFile);
    }
}