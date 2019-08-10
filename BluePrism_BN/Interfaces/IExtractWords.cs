using System;
using System.Collections.Generic;

namespace BluePrism_BN
{
    public interface IExtractWords
    {
        IList<string> ExtractWordsByLength(string DictionaryFilePath, string StartWord);
       
    }
}
