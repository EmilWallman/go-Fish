using System;
using System.Collections.Generic;
using System.Threading;

namespace goFish
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start question
            bool start = startYN();

            //Start if loop (the whole game)
            if (start == true)
            {

                var tupleList = new List<(int, string)> 
                { 
                    
                };




                List<int> hand = new List<int>() { };
                List<int> computerhand = new List<int>() { };









            }


            //If you dont want to play
            else
            {
                Console.WriteLine("Oh... Okay... Bye then :(");
            }



        }

        //start question
        static bool startYN()
        {
            bool YN;

            Console.WriteLine("Welcome to goFish do you want to play a game? Y/N");
            string YNstring = Console.ReadLine();

            if (YNstring == "Y" || YNstring == "y")
            {
                YN = true;
                
            }

            else
            {
                YN = false;
            }

            return YN;
        }
        
    }
}
