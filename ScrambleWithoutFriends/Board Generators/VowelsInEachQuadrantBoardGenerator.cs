using System;
using System.Collections.Generic;

namespace ScrambleWithoutFriends.Board_Generators
{
    public class VowelsInEachQuadrantBoardGenerator : IScrambleBoardGenerator
    {
        #region IScrambleBoardGenerator Members

        public void PopulateBoard(ScrambleBoard scrambleBoard)
        {
            var vowels = new[] {'a', 'e', 'i', 'o', 'u'};
            var consonants = new[]
                                 {
                                     'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v',
                                     'w', 'x', 'y', 'z'
                                 };
            IEnumerable<Quadrant> quadrants = GenerateQuadrants(scrambleBoard);

            var random = new Random();
            foreach (Quadrant quadrant in quadrants)
            {
                int randomXPositionInQuadrant = random.Next(quadrant.StartingXIndex, quadrant.EndingXIndex);
                int randomYPositionInQuadrant = random.Next(quadrant.StartingYIndex, quadrant.EndingYIndex);
                char randomVowel = vowels[random.Next(vowels.Length - 1)];
                for (int x = quadrant.StartingXIndex; x <= quadrant.EndingXIndex; x++)
                {
                    for (int y = quadrant.StartingYIndex; y <= quadrant.EndingYIndex; y++)
                    {
                        if(x == randomXPositionInQuadrant && y == randomYPositionInQuadrant)
                            scrambleBoard[randomXPositionInQuadrant, randomYPositionInQuadrant] = randomVowel;
                        else
                            scrambleBoard[x, y] = consonants[random.Next(consonants.Length - 1)];
                    }
                }
                    
            }
        }

        #endregion

        private IEnumerable<Quadrant> GenerateQuadrants(ScrambleBoard scrambleBoard)
        {
            var quadrants = new[] {new Quadrant(Quadrant.TopLeftQuadrant), new Quadrant(Quadrant.TopRightQuadrant), new Quadrant(Quadrant.BottomLeftQuadrant), new Quadrant(Quadrant.BottomRightQuadrant)};
            quadrants[Quadrant.TopLeftQuadrant].StartingYIndex = quadrants[Quadrant.TopLeftQuadrant].StartingXIndex = quadrants[Quadrant.BottomLeftQuadrant].StartingXIndex = quadrants[Quadrant.TopRightQuadrant].StartingYIndex = 0;
            quadrants[Quadrant.BottomRightQuadrant].EndingXIndex = quadrants[Quadrant.TopRightQuadrant].EndingXIndex = scrambleBoard.Length - 1;
            quadrants[Quadrant.BottomRightQuadrant].EndingYIndex = quadrants[Quadrant.BottomLeftQuadrant].EndingYIndex = scrambleBoard.Width - 1;

            quadrants[Quadrant.TopLeftQuadrant].EndingXIndex = quadrants[Quadrant.TopRightQuadrant].StartingXIndex = (int) Math.Floor(scrambleBoard.Width/2.0);
            quadrants[Quadrant.BottomLeftQuadrant].EndingXIndex = quadrants[Quadrant.BottomRightQuadrant].StartingXIndex = (int) Math.Floor(scrambleBoard.Width/2.0);
            quadrants[Quadrant.TopLeftQuadrant].EndingYIndex = quadrants[Quadrant.BottomLeftQuadrant].StartingYIndex = (int) Math.Floor(scrambleBoard.Length/2.0);
            quadrants[Quadrant.TopRightQuadrant].EndingYIndex = quadrants[Quadrant.BottomRightQuadrant].StartingYIndex = (int) Math.Floor(scrambleBoard.Length/2.0);

            return quadrants;
        }
    }

    internal class Quadrant
    {
        public static readonly int TopLeftQuadrant = 0,
                                   TopRightQuadrant = 1,
                                   BottomLeftQuadrant = 2,
                                   BottomRightQuadrant = 3;

        private int _quadrantIdentifier;

        public int StartingXIndex { get; set; }
        public int StartingYIndex { get; set; }
        public int EndingXIndex { get; set; }
        public int EndingYIndex { get; set; }
        public int QuadrantIdentifier { get { return _quadrantIdentifier; } private set { _quadrantIdentifier = value; } }

        public int GetLength()
        {
            return EndingXIndex - StartingXIndex;
        }

        public int GetWidth()
        {
            return EndingYIndex - StartingYIndex;
        }

        public Quadrant(int quadrantIdentifier)
        {
            _quadrantIdentifier = quadrantIdentifier;
        }
    }
}