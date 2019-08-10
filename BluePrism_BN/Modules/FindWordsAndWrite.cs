using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BluePrism_BN
{

    public class FindWordsAndWrite: IFindWordsAndWrite
    {
        public FindWordsAndWrite() 
        {

        }

        private readonly IExtractWords _extractWords = new ExtractWords();
        public FindWordsAndWrite(IExtractWords extractWords)
        {
            extractWords = _extractWords; 
        }

        public void Execute_FindWordsOneLetterDifference(string DictionaryFilePath, string StartWord, string EndWord, string OutputFilePath)
        {
            // By extracting the word by length, I am able to find words, regardless of word length, with one letter difference from the DictionaryFilePath
            var words = _extractWords.ExtractWordsByLength(DictionaryFilePath, StartWord);
            var resultFileWords = FindWords_OneLetterDifference(words, StartWord, EndWord);
            var containsNoMatchedWords = containsNoIntermediateWords(StartWord, EndWord, resultFileWords);

            if(containsNoMatchedWords != true)
            {
                PrintListOfWords(resultFileWords);
                writeToOutputFile(OutputFilePath, resultFileWords);
            }
            else
            {
                Console.WriteLine("Found no intermediate words!");
            }
        }


        public IList<string> FindWords_OneLetterDifference(IList<string> wordsBySpecifiedLength, string StartWord, string EndWord)
        {
            IList<string> words = new List<string>();
            IList<string> resultWordList = new List<string>();

            IList<int> indexesMatched = new List<int>();
            IList<int> remainingIndexes = new List<int>();

            string wordAfter = "";

            char[] StartWordSplit = StartWord.ToLower().ToCharArray();
            char[] EndWordSplit = EndWord.ToLower().ToCharArray();

            char[] splitWordBefore = StartWordSplit;
            char[] splitWordAfter = null;

            var findLetterEquality = findLetterEquality_BetweenStartAndEndWord(indexesMatched, remainingIndexes, StartWordSplit, EndWordSplit);
            int noOfIndexesToMatch = findLetterEquality.Item3;

            int differentLetters = 0;
            int sameLetters = 0;

            resultWordList.Add(StartWord);

            for (int x = 0; x < wordsBySpecifiedLength.Count(); x++)
            {
                wordAfter = wordsBySpecifiedLength[x].ToLower();
                splitWordAfter = wordsBySpecifiedLength[x].ToLower().ToCharArray();

                differentLetters = 0;
                sameLetters = 0;

                for (int i = 0; i < indexesMatched.Count(); i++)
                {
                    if(splitWordBefore[indexesMatched[i]] == splitWordAfter[indexesMatched[i]])
                    {
                        sameLetters++;
                    }
                    if (splitWordBefore[indexesMatched[i]] != splitWordAfter[indexesMatched[i]])
                    {
                        differentLetters++;
                    }
                }

                for(int i = 0; i < remainingIndexes.Count(); i++)
                {
                    if(splitWordBefore[remainingIndexes[i]] != splitWordAfter[remainingIndexes[i]])
                    {
                        differentLetters++;
                    }
                }

                if (sameLetters == noOfIndexesToMatch)
                {
                    if(differentLetters == 1)
                    {
                        int differenceByOne = 0;
                        for(int y =0; y < EndWordSplit.Count(); y++)
                        {
                            if(splitWordAfter[y] != EndWordSplit[y])
                            {
                                differenceByOne++;
                            }
                        }
                        if(differenceByOne == 1)
                        {
                            resultWordList.Add(wordAfter);
                        }
                    }
                }
            }
            resultWordList.Add(EndWord);
            return resultWordList;
        }

        (IList<int>, IList<int>, int) findLetterEquality_BetweenStartAndEndWord(IList<int> indexesMatched, IList<int> remainingIndexes, char[] StartWordSplit, char[] EndWordSplit)
        {

            int noOfIndexesToMatch = 0;
            for (int i = 0; i < StartWordSplit.Count(); i++)
            {
                if (StartWordSplit[i] == EndWordSplit[i])
                {
                    indexesMatched.Add(i);
                }
                else
                {
                    remainingIndexes.Add(i);
                }
                noOfIndexesToMatch = indexesMatched.Count();
            }
            return (indexesMatched, remainingIndexes, noOfIndexesToMatch);
        }

        void PrintListOfWords(IList<string> resultWordList)
        {

            Console.WriteLine("List contains: ");

            foreach (var word in resultWordList)
            {
                Console.WriteLine(word);
            }
        }

        void writeToOutputFile(string OutputFilePath, IList<string> ResultWordList)
        {
            if (OutputFilePath == "")
            {
                Console.WriteLine("Result file path must contain value!");
                System.Environment.Exit(1);
            }

            StreamWriter streamWriter = new StreamWriter(OutputFilePath);
            foreach(var word in ResultWordList)
            {
                streamWriter.WriteLine(word);
            }
            streamWriter.Close();
        }
        bool containsNoIntermediateWords(string StartWord, string EndWord, IList<string> ResultWordList)
        {
            bool flag = false;
            if(ResultWordList[0] == StartWord)
            {
                if(ResultWordList[1] == EndWord)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}