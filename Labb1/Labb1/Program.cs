using System;

namespace Labb1
{
    class Program
    {
        private static string Input;
        private static string StartOfSubstring;
        private static int FirstIndex;
        private static int SecondIndex;
        private static long SumOfSubstrings = 0;
        static void Main(string[] args)
        {         
            //Ber användaren om en sträng samt sparar ner denna sträng i Input.
            Console.WriteLine("Input a string.");
            Input = Console.ReadLine();

            //Skriver ut inputen samt kallar på LookForIntegerInString metoden.
            Console.WriteLine($"Output för input {Input}:");
            LookForIntegerInString();
            
            //Skriver ut totalen av alla substrängar alltså sumOfSubstrings.
            Console.WriteLine($"Total = {SumOfSubstrings}");
        }
        
        //denna metoden letar efter en substräng som börjar och slutar på samma siffra.
        public static void LookForIntegerInString ()
        {
            //Letar efter en siffra i strängen. Om den hittar en siffra så sparar den ner dess index i FirstIndex samt sparar ner vilken siffra det är i StartOfSubstring.
            for (int i = 0; i < Input.Length; i++)
            {
                if (int.TryParse(Input.Substring(i, 1), out int number))
                {
                    FirstIndex = i;
                    StartOfSubstring = number.ToString();
                    
                    //Letar efter nästa siffra som är likadan samt sparar ner dess index i SecondIndex. Kallar sedan på LookForLetters metoden.
                    //Den skickar även med ett argument till LookForLetters metoden som är substrängen, alltså från den siffran den hittade tills nästa siffra som är likadan.
                    for (int j = FirstIndex + 1; j < Input.Length; j++)
                    {
                        if (Input.Substring(j, 1) == StartOfSubstring)
                        {
                            SecondIndex = j;
                            LookForLetters(Input.Substring(FirstIndex, SecondIndex - FirstIndex + 1));
                            break;
                        }
                    }
                }
            }
        }
        
        //Denna metoden kollar så att substrängen inte innehåller någon bokstav.
        //Om den inte innehåller någon bokstav så plussar den på talet på SumOfSubstrings samt kallar på PrintString metoden med substrängen som argument.
        //Om den innehåller en bokstav så återvänder den till LookForIntegerInString metoden.
        public static void LookForLetters (string subString)
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
            SumOfSubstrings += long.Parse(subString);
            PrintString(subString);
        }
        
        //Denna metoden skriver ut strängen samt ändrar färg på substrängen.
        public static void PrintString(string subString)
        {          
            //Skriver ut början av strängen fram tills firstIndex.        
            Console.Write(Input.Substring(0, FirstIndex));           
            
            //Ändrar färg till röd samt skriver ut substrängen.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(subString);

            //Byter tillbaks färgen till grå samt Skriver ut resterande av strängen från secondIndex + 1 tills slutet av strängen.
            Console.ForegroundColor = ConsoleColor.Gray;           
            Console.Write(Input.Substring(SecondIndex + 1, Input.Length - (FirstIndex + subString.Length)));
           
            //Byter rad.
            Console.WriteLine("");
        }
    }
}
