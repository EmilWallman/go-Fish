using System;
using System.Collections.Generic;
using System.Threading;

namespace goFish
{

    class Program

    {
        static void Main(string[] args)
        {
            //values



            //Start question
            bool start = startYN();

            //Start if loop (the whole game)
            if (start == true)
            {
                //making a deck of cards
                List<int> cardValue = CV();
                List<string> cardColour = CC();
                List<int> cardNum = cardN();
                
                //for player and computer
                List<int> hand = new List<int> { };
                List<int> computerHand = new List<int> { };

                //Dealing cards
                for(int i = 0; i < 7; i++)
                {
                    hand = dealer(cardNum, hand);
                    cardNum.Remove(hand[i]);

                    computerHand = dealer(cardNum, computerHand);
                    cardNum.Remove(computerHand[i]);
                }
                bool game = true;

                while (game == true)
                {
                    //1 is player turn 2 is computer
                    int cp = 1;

                    if (cp == 1)
                    {

                        ui(hand, computerHand, cardNum, cardValue, cardColour, cp);

                        int answer = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < computerHand.Count; i++)
                        {
                            if (cardValue[hand[answer - 1]] == cardValue[computerHand[i]])
                            {
                                Console.WriteLine("bög");
                            }
                        }

                    }

                    if (cp == 2)
                    {

                    }



                }

            }

            //If you dont want to play
            else
            {
                Console.WriteLine("Oh... Okay... Bye then :(");
            }
        }

        //UI
        static void ui(List<int> hand, List<int> compterHand, List<int> cardNum, List<int> cardValue, List<string> cardColour, int cp)
        {
            hand.Sort();
            compterHand.Sort();


            Console.Clear();
            Console.WriteLine("==================================================================================================================");
            Console.WriteLine("");
            Console.WriteLine("==============");
            Console.WriteLine(" Your cards:");
            for(int i = 0; i < hand.Count; i++)
            {
                switch (cardValue[hand[i]])
                {
                    case 11:
                        Console.WriteLine((i + 1) + ") "  + cardColour[hand[i]] + "  " + "Jack");
                        break;
                    case 12:
                        Console.WriteLine((i + 1) + ") " + cardColour[hand[i]] + "  " + "Queen");
                        break;
                    case 13:
                        Console.WriteLine((i + 1) + ") " + cardColour[hand[i]] + "  " + "King");
                        break;

                    default:
                        Console.WriteLine((i + 1) + ") "  + cardColour[hand[i]] + "  " + cardValue[hand[i]]);
                        continue;
                }

                
            }

            Console.WriteLine("");
            Console.WriteLine("");
            if (cp == 1)
            {
                Console.WriteLine("Ask the computer for a card");
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

        //For colours
        static List<string> CC()
        {
            List<string> name = new List<string>();
            List<string> CName = new List<string>() {"Spades    ", "Diamonds  ", "Hearts    ", "Clubs     " };
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

        //numbers 1-52
        static List<int> cardN()
        {
            List<int> cardNum = new List<int>();

            for (int i = 0; i < 52; i++)
            {
                cardNum.Add(i);
            }

            return cardNum;
        }

        //random
        static int rnd(List<int> numbers)
        {
            Random rnd = new Random();
            int randomEfx = rnd.Next(0, numbers.Count);

            return randomEfx;
        }

        static List<int> dealer(List<int> numbers, List<int> hand)
        {
            int random = rnd(numbers);
            int number = numbers[random];
            hand.Add(number);

            return hand;
        }

    }
}
