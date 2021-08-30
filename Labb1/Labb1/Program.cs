using System;

namespace Labb1
{
    class Program
    {
        static string _input;
        static int _firstIndex;
        static int _secondIndex;
        static long _sumOfSubstrings = 0;
        static void Main(string[] args)
        {
            //Ber användaren om en sträng samt sparar ner denna sträng i Input.
            //Skriver sedan ut inputen samt kallar på SearchForInteger metoden.
            Console.WriteLine("Input a string:");
            _input = Console.ReadLine();
            Console.WriteLine($"Output för input {_input}:");
            SearchForInteger();
            
            //Skriver ut totalen av alla substrängar alltså sumOfSubstrings.
            Console.WriteLine($"Total = {_sumOfSubstrings}");
        }

        //Denna metoden letar efter en siffra i strängen. Om den hittar en siffra så sparar den ner dess index i _firstIndex samt sparar ner vilken siffra det är i startOfSubstring.
        //Letar efter nästa siffra som är likadan samt sparar ner dess index i _secondIndex. Kallar sedan på SearchForLetter metoden med substrängen som argument.
        private static void SearchForInteger ()
        {          
            for (int i = 0; i < _input.Length; i++)
            {
                if (int.TryParse(_input.Substring(i, 1), out int number))
                {
                    _firstIndex = i;
                    string startOfSubstring = number.ToString();
                    
                    for (int j = _firstIndex + 1; j < _input.Length; j++)
                    {
                        if (_input.Substring(j, 1) == startOfSubstring)
                        {
                            _secondIndex = j;
                            SearchForLetter(_input.Substring(_firstIndex, _secondIndex - _firstIndex + 1));
                            break;
                        }
                    }
                }
            }
        }

        //Denna metoden kollar så att substrängen inte innehåller någon bokstav.
        //Om den inte innehåller någon bokstav så plussar den på talet på _sumOfSubstrings samt kallar på PrintString metoden med substrängen som argument.
        //Om den innehåller en bokstav så återvänder den till SearchForInteger metoden.
        private static void SearchForLetter (string subString)
        {
            for (int i = 0; i < subString.Length; i++)
            {
                if (int.TryParse(subString.Substring(i, 1), out int x))
                {
                    continue;
                }
                else
                {
                    return;
                }
            }
            _sumOfSubstrings += long.Parse(subString);
            PrintString(subString);
        }
        
        //Denna metoden delar upp inputen i 3 delar. första delen är innan substrängen, andra delen är substrängen och tredje delen är resterande av inputen.
        //Den skriver sedan ut dessa delar var för sig samt byter färg på substrängen till röd.
        private static void PrintString(string subString)
        {
            string firstPartOfInput = _input.Substring(0, _firstIndex);
            string secondPartOfInput = _input.Substring(_secondIndex + 1, _input.Length - (_firstIndex + subString.Length));
       
            Console.Write(firstPartOfInput);                      
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(subString);
            Console.ForegroundColor = ConsoleColor.Gray;           
            Console.Write(secondPartOfInput);
            
            Console.WriteLine("");
        }
    }
}
