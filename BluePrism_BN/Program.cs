using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BluePrism_BN
{
    public class MainClass
    {
        public static readonly IFindWordsAndWrite findWordsAndWrite = new FindWordsAndWrite();
        public static readonly IExtractWords readWords = new ExtractWords();

        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path of dictionary file: ");
            string dictionaryFile = Console.ReadLine();
            Console.WriteLine("Please enter the start word: ");
            string startWord = Console.ReadLine();
            Console.WriteLine("Please enter the end word: ");
            string endWord = Console.ReadLine();
            Console.WriteLine("Please enter the path of the output file: ");
            string outputFile = Console.ReadLine();
            Console.WriteLine();


            findWordsAndWrite.Execute_FindWordsOneLetterDifference(dictionaryFile, startWord, endWord, outputFile);


            //// or
            //var words = readWords.ExtractWordsByLength(dictionaryFile, startWord);
            //findWordsAndWrite.FindWords_OneLetterDifference(words, startWord, endWord, outputFile);

        }

    }
}











/*
 _      `-._     `-.     `.   \      :      /   .'     .-'     _.-'      _
`--._     `-._    `-.    `.  `.    :    .'  .'    .-'    _.-'     _.--'
  `--._    `-._   `-.   `.  \   :   /  .'   .-'   _.-'    _.--'
`--.__     `--._   `-._  `-.  `. `. : .' .'  .-'  _.-'   _.--'     __.--'
__    `--.__    `--._  `-._ `-. `. \:/ .' .-' _.-'  _.--'    __.--'    __
`--..__   `--.__   `--._ `-._`-.`_=_'.-'_.-' _.--'   __.--'   __..--'
--..__   `--..__  `--.__  `--._`-q(-_-)p-'_.--'  __.--'  __..--'   __..--
  ``--..__  `--..__ `--.__ `-'_) (_`-' __.--' __..--'  __..--''
...___        ``--..__ `--..__`--/__/  \--'__..--' __..--''        ___...
  ```---...___    ``--..__`_(<_   _/)_'__..--''    ___...---'''
```-----....._____```---...___(__\_\_|_/__)___...---'''_____.....-----'''
___   __  ________   _______   _       _   _______    ___   __   _______
|| \\  ||     ||     ||_____))  \\     //  ||_____||  || \\  ||  ||_____||
||  \\_||  ___||___  ||     \\   \\___//   ||     ||  ||  \\_||  ||     || */

