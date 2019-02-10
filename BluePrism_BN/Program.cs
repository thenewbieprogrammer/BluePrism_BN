using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BluePrism_BN
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ReadAndWriteClass readAndWriteClass = new ReadAndWriteClass();
            readAndWriteClass.readAndWriteFourLetterValues();
        }

    }


    class FilterWordsClass
    {

        public void FilterValues(List<string> fourLetterWords)
        {
            int differentLetters = 0;

            string wordBefore = "";
            string wordAfter = "";



            for (int i=0; i<fourLetterWords.Count(); i++)
            {
                wordBefore = fourLetterWords[i];
                char[] splitWordBefore = wordBefore.ToCharArray();
                char[] splitWordAfter = null;
                for (int j = 1; j <= fourLetterWords.Count(); j++)
                {
                    wordAfter = fourLetterWords[j];
                    splitWordAfter = wordAfter.ToCharArray();

                }
                
                for(int i2 = 0; i2 < splitWordBefore.Count(); i2++)
                {
                    for(int j2 = 0; j2 < splitWordAfter.Count(); j2++)
                    {
                        if(i2 != j2)
                        {
                            differentLetters++;
                        }
                    }
                }

            }
        }
    }

    class ReadAndWriteClass
    {
        StreamReader streamReader = new StreamReader("./words-english.txt");
        StreamWriter streamWriter = new StreamWriter("./new-words.txt");
        string line;
        List<string> fourLetterWords = new List<string>();


        public void readAndWriteFourLetterValues()
        {
            Console.WriteLine("Reading first value from text file");

            
            int wordCount = 0;
            try
            {
                line = streamReader.ReadLine();
                while (line != null)
                {
                    for (int i = 0; i < line.Count(); i++)
                    {
                        if(line != null)
                        {
                            int letterCount = 0;
                            foreach (var letter in line)
                            {
                                Console.WriteLine("letter = " + letter + " count = " + letterCount);
                                letterCount++;
                            }

                            if (letterCount == 4)
                            {
                                var regexItem = new Regex("^[a-zA-Z]*$");
                                if(regexItem.IsMatch(line))
                                {
                                    wordCount++;
                                    fourLetterWords.Add(line);
                                    streamWriter.WriteLine(line);
                                    Console.WriteLine(line);
                                }

                            }

                        }
                        line = streamReader.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e.Message);
            }
            finally
            {
                Console.WriteLine("executing finally block and writing four-letter words to new-text file...");

                Console.WriteLine("Executing the FilterValues function");
                FilterWordsClass filterWordsClass = new FilterWordsClass();
                filterWordsClass.FilterValues(fourLetterWords);
            }


        }
    }


}
