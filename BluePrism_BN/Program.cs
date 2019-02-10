using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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

        }
    }

    class ReadAndWriteClass
    {
        StreamReader streamReader = new StreamReader("/Users/bilaal/Projects/BluePrism_BN/words-english.txt");
        StreamWriter streamWriter = new StreamWriter("/Users/bilaal/Projects/BluePrism_BN/new-words.txt");
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
                                wordCount++;
                                fourLetterWords.Add(line);
                                streamWriter.WriteLine(line);
                                Console.WriteLine(line);
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

                Console.WriteLine("Executing the proper function");
                FilterWordsClass filterWordsClass = new FilterWordsClass();
                filterWordsClass.FilterValues(fourLetterWords);
            }


        }
    }


}
