using System;
using System.Collections.Generic;

namespace RomanNumberContract
{
    public interface IRomanNumberRepository
    {
        List<string> GetValidCharacterWithLengthOne();
        List<string> GetValidCharacterWithLengthTwo();
        List<Tuple<string, string>> GetForbidenCharacterFollowingCombinaison();
        int TransformBackFromUnit(string curChar);
        string TransformToUnit(int number);
    }
}
