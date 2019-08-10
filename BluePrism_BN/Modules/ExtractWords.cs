using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BluePrism_BN
{
    public class ExtractWords: IExtractWords
    {

        public IList<string> ExtractWordsByLength(string DictionaryFilePath, string StartWord)
        {
            if(DictionaryFilePath == "" || StartWord == "")
            {
                Console.WriteLine("All params must contain value!: Please check params.");
                System.Environment.Exit(1);
            }

            StreamReader streamReader;


            List<string> words = new List<string>();

            string line;

            int wordCount = 0;
            int wordLength = StartWord.Length;

            try
            {
                streamReader = new StreamReader(DictionaryFilePath);
                line = streamReader.ReadLine();
                while (line != null)
                {

                    if (line != null)
                    {
                        int letterCount = 0;
                        foreach (var letter in line)
                        {
                            letterCount++;
                        }
                        if (letterCount == wordLength)
                        {
                            var regexItem = new Regex("^[a-zA-Z]*$");
                            if (regexItem.IsMatch(line))
                            {
                                wordCount++;
                                words.Add(line);
                            }
                        }
                    }
                    line = streamReader.ReadLine();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e.Message);
            }
            return words;
        }
    }
}
