using System;
namespace BluePrism_BN
{
    public class FindWordEntity
    {
        public FindWordEntity()
        {
        }

        public string DictionaryFile { get; set; }
        public string StartWord { get; set; }
        public string EndWord { get; set; }
        public string OutputFile { get; set; }


        public void askForInput()
        {
            Console.WriteLine("Please enter the path of dictionary file: ");
            string dictionaryFile = Console.ReadLine();
            Console.WriteLine("Please enter the start word: ");
            string startWord = Console.ReadLine();
            Console.WriteLine("Please enter the end word: ");
            string endWord = Console.ReadLine();
            Console.WriteLine("Please enter the path of the output file: ");
            string outputFile = Console.ReadLine();

            DictionaryFile = dictionaryFile;
            StartWord = startWord;
            EndWord = endWord;
            OutputFile = outputFile;

            IsValid();

            if(IsValid() != true)
            {
                DictionaryFile.Remove(0);
                StartWord.Remove(0);
                EndWord.Remove(0);
                OutputFile.Remove(0);
                Console.WriteLine("False entries, please try again!");
            }
        }

        public bool IsValid()
        {
            bool isValid = false;

            if (DictionaryFile.StartsWith("/", StringComparison.Ordinal) || DictionaryFile.StartsWith(".", StringComparison.Ordinal))
            {
                isValid = true;
            }


            if (OutputFile.StartsWith("/", StringComparison.Ordinal) || OutputFile.StartsWith(".", StringComparison.Ordinal))
            {
                isValid = true;
            }

            if (StartWord == null && EndWord == null)
            {
                isValid = false;
            } 


            return isValid;
        }

    }
}
