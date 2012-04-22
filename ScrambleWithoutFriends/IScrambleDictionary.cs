using System.Collections.Generic;

namespace ScrambleWithoutFriends
{
    public interface IScrambleDictionary
    {
        IList<string> WordList { get; }
        void BuildDictionary(string dictionaryFile);
    }
}