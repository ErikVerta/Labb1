using System;

namespace Labb1
{
    class Program
    {
        public static string Input;
        public static int firstIndex;
        public static int secondIndex;
        public static long sumOfSubstrings = 0;
        static void Main(string[] args)
        {         
            //Ber användaren om en sträng samt sparar ner denna sträng i Input.
            Console.WriteLine("Input a string.");
            Input = Console.ReadLine();

            //Skriver ut inputen samt kallar på LookForIntegerInString metoden.
            Console.WriteLine($"Output för input {Input}:");
            LookForIntegerInString();
            
            //Skriver ut totalen av alla substrängar alltså sumOfSubstrings.
            Console.WriteLine($"Total = {sumOfSubstrings}");
        }
        
        //denna metoden letar efter en substräng som börjar och slutar på samma siffra.
        public static void LookForIntegerInString ()
        {
            //Letar efter en siffra i strängen. Om den hittar en siffra så sparar den ner dess index i firstIndex samt sparar ner vilken siffra det är i startOfSubstring.
            for (int i = 0; i < Input.Length; i++)
            {
                if (int.TryParse(Input.Substring(i, 1), out int x))
                {
                    firstIndex = i;
                    string startOfSubstring = Input.Substring(i, 1);
                    
                    //Letar efter nästa siffra som är likadan samt sparar ner dess index. Kallar sedan på LookForLetters metoden.
                    for (int z = firstIndex + 1; z < Input.Length; z++)
                    {
                        if (Input.Substring(z, 1) == startOfSubstring)
                        {
                            secondIndex = z;
                            LookForLetters(Input.Substring(firstIndex, secondIndex - firstIndex + 1));
                            break;
                        }
                    }
                }
            }
        }
        
        //Denna metoden kollar så att substrängen inte innehåller någon bokstav.
        //Om den inte innehåller någon bokstav så plussar den på talet på sumOfSubstrings samt kallar på PrintString metoden.
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
            sumOfSubstrings += long.Parse(subString);
            PrintString();
        }
        
        //Denna metoden skriver ut strängen samt ändrar färg på substrängen.
        public static void PrintString()
        {          
            //Skriver ut varje symbol i strängen fram tills firstIndex.
            for (int i = 0; i < firstIndex; i++)
            {
                Console.Write(Input.Substring(i, 1));
            }
            
            //Ändrar färg till röd samt skriver ut varje symbol från firstIndex till och med secondIndex, alltså hela substrängen.
            for (int i = firstIndex; i <= secondIndex; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Input.Substring(i, 1));
            }
            
            //Byter tillbaks färgen till grå.
            Console.ForegroundColor = ConsoleColor.Gray;
            
            //Skriver ut varje symbol från secondIndex + 1 tills slutet av strängen, alltså resten av strängen.
            for (int i = secondIndex + 1; i < Input.Length; i++)
            {
                Console.Write(Input.Substring(i, 1));
            }
            
            //Byter rad.
            Console.WriteLine("");
        }
    }
}
