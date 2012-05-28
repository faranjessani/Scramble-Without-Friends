namespace ScrambleWithoutFriends
{
    internal interface IScrambleDictionary
    {
        WordNode RootNode { get; }
        void BuildDictionary(string dictionaryFile);
    }
}