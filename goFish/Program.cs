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
                List<int> cardsValue = CV();
                List<string> cardsName = CN();
                List<int> cardNum = cardN();
                Console.WriteLine("bög");


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

        //For values
        static List<int> CV()
        {
            List<int> value = new List<int>();
            int i = 1;
            int x = 0;
            int y = 0;
            bool go = true;

            while (go == true)
            {
                if (x < 4)
                {
                    value.Add(i);
                    x++;
                }
                else
                {
                    x = 0;
                    i++;
                }
                if (i == 14)
                {
                    go = false;
                }
                
            }

            return value;


        }

        //For names
        static List<string> CN()
        {
            List<string> name = new List<string>();
            List<string> CName = new List<string>() {"Spades", "Diamonds", "Hearts", "Clubs" };
            int i = 1;
            int x = 0;
            int y = 0;
            bool go = true;

            while (go == true)
            {
                if (x < 4)
                {
                    name.Add(CName[x]);
                    x++;
                }
                else
                {
                    x = 0;
                    i++;
                }

                if (i == 14)
                {
                    go = false;
                }
                
            }
            return name;
        }

        static List<int> cardN()
        {
            List<int> cardNum = new List<int>();

            for (int i = 0; i < 52; i++)
            {
                cardNum.Add(i);
            }

            return cardNum;
        }

        
    }
}
