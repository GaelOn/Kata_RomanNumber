using System;
using System.Collections.Generic;
using RomanNumberContract;

namespace RomanNumberData
{
    public class RomanUnitRepository : IRomanNumberRepository
    {
        public List<Tuple<string, string>> GetForbidenCharacterFollowingCombinaison()
        {
            return RomanUnit.GetForbidenCharacterFollowingCombinaison();
        }

        public List<string> GetValidCharacterWithLengthOne()
        {
            return RomanUnit.GetValidCharacterWithLengthOne();
        }

        public List<string> GetValidCharacterWithLengthTwo()
        {
            return RomanUnit.GetValidCharacterWithLengthTwo();
        }

        public string TransformToUnit(int number)
        {
            return RomanUnit.TransformToUnit(number);
        }

        public int TransformBackFromUnit(string curChar)
        {
            return RomanUnit.TransformBackFromUnit(curChar);
        }
    }
}
