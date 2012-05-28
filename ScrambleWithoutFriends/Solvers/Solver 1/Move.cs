using System;

namespace ScrambleWithoutFriends
{
    internal struct Move : ICloneable
    {
        public int X, Y;

        public Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        #region ICloneable Members

        public object Clone()
        {
            return new Move(X, Y);
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof (Move)) return false;
            var move = (Move) obj;
            if (X == move.X && Y == move.Y) return true;

            return false;
        }

        public override int GetHashCode()
        {
            return X + Y;
        }
    }
}