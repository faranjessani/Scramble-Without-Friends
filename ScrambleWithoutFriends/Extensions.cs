namespace ScrambleWithoutFriends
{
    public static class Extensions
    {
        public static int ToNodeIndex(this char character)
        {
            return char.ToLower(character) - 'a';
        }
    }
}