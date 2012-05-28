namespace ScrambleWithoutFriends
{
    public class WordNode
    {
        public WordNode()
        {
            ChildNodes = new WordNode[26];
        }

        public WordNode[] ChildNodes { get; set; }
        public bool EndOfWord { get; set; }
        public string Word { get; set; }
    }
}