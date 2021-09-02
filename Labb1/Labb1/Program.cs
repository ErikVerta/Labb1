using System;


namespace Labb1
{
    class Program
    {
        static string _input;
        static int _firstIndex;
        static int _secondIndex;
        static long _sumOfNumbers = 0;
        static void Main(string[] args)
        {
            //Ber användaren om en sträng samt sparar ner denna sträng i Input.
            //Skriver sedan ut inputen samt kallar på SearchForInteger metoden.
            Console.WriteLine("Input a string:");
            _input = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Output for input {_input}:");
            SearchForInteger();
            
            //Skriver ut totalen av alla substrängar alltså sumOfSubstrings.
            Console.WriteLine($"Total = {_sumOfNumbers}");
        }

        //Denna metoden letar efter en siffra i strängen. Om den hittar en siffra så sparar den ner vilken siffra det är samt dess index.
        //Letar sedan vidare efter en likadan siffra, om den hittar en bokstav innan den hittar en likadan siffra så avbryter den loopen och går tillbaks till första loopen.
        //Om den hittar en likadan siffra innan den hittar en bokstav så sparar den ner dess index samt sparar ner alla siffror mellan första och andra index.
        //Sen plussar den på talet på _sumOfNumbers samt kallar på PrintString metoden med talet som argument.
        private static void SearchForInteger ()
        {          
            for (int i = 0; i < _input.Length; i++)
            {
                if (int.TryParse(_input.Substring(i, 1), out int number))
                {
                    _firstIndex = i;
                    string startOfNumberString = number.ToString();
                    
                    for (int j = _firstIndex + 1; j < _input.Length; j++)
                    {
                        if (_input[j].ToString() == startOfNumberString)
                        {
                            _secondIndex = j;
                            string numberString = _input.Substring(_firstIndex, _secondIndex - _firstIndex + 1);
                            _sumOfNumbers += long.Parse(numberString);
                            PrintString(numberString);
                            break;
                        }
                        else if (int.TryParse(_input.Substring(j, 1), out int x) == false )
                        {
                            break;
                        }
                    }
                }
            }
        }
             
        //Denna metoden delar upp inputen i 3 delar. första delen är innan talet, andra delen är talet och tredje delen är resterande av inputen.
        //Den skriver sedan ut dessa delar var för sig samt byter färg på talet till röd.
        private static void PrintString(string numberString)
        {
            string firstPartOfInput = _input.Substring(0, _firstIndex);
            string secondPartOfInput = _input.Substring(_secondIndex + 1);
            Console.Write(firstPartOfInput);                      
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(numberString);
            Console.ForegroundColor = ConsoleColor.Gray;           
            Console.Write(secondPartOfInput);
            
            Console.WriteLine("");
        }
    }
}
