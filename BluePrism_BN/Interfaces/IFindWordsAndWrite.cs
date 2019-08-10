using System;
using System.Collections.Generic;

namespace BluePrism_BN
{
    public interface IFindWordsAndWrite
    {
        void Execute_FindWordsOneLetterDifference(string DictionaryFilePath, string StartWord, string EndWord, string OutputFilePath);
        IList<string> FindWords_OneLetterDifference(IList<string> wordsBySpecifiedLength, string StartWord, string EndWord);
    }
}
