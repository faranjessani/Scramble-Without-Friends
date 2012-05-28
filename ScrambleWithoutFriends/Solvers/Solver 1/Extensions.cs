using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
