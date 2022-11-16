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
            if (start)
            {
                //making a deck of cards
                List<int> cardValue = CV();
                List<string> cardColour = CC();
                List<int> cardNum = cardN();
                
                //for player and computer
                List<int> hand = new List<int> { };
                List<int> computerHand = new List<int> { };

                //For game
                int cardCount = 0;

                int num1 = 0;
                int num2 = 0;
                int num3 = 0;

                int compNum1 = 0;
                int compNum2 = 0;


                bool computerAgain = false;
                bool computerTry = true;
                //if the question was succesfull or nah
                int work = 0;

                //1 is player turn 2 is computer
                int cp = 1;

                //Dealing cards
                for (int i = 0; i < 7; i++)
                {
                    hand = dealer(cardNum, hand);
                    cardNum.Remove(hand[i]);

                    computerHand = dealer(cardNum, computerHand);
                    cardNum.Remove(computerHand[i]);
                }
                bool game = true;

                while (game)
                {
                    

                    if (cp == 1)
                    {

                        ui(hand, computerHand, cardNum, cardValue, cardColour, cp, work);

                        int answer = Convert.ToInt32(Console.ReadLine());
                        int j = 0;
                        for (int i = 0; i < computerHand.Count; i++)
                        {
                            if (cardValue[hand[answer - 1]] == cardValue[computerHand[i]])
                            {
                                int taker = computerHand[i];
                                hand.Add(taker);
                                computerHand.RemoveAt(i);
                                
                                
                                
                                work = 1;
                                ui(hand, computerHand, cardNum, cardValue, cardColour, cp, work);
                                work = 0;

                                i = 0;
                            }

                            else
                            {
                                
                                j++;
                                if (j == computerHand.Count)
                                {
                                    Console.WriteLine("The computer did not have the card you asked for");

                                    hand = dealer(cardNum, hand);
                                    cardNum.Remove(hand[hand.Count - 1]);
                                    ui(hand, computerHand, cardNum, cardValue, cardColour, cp, work);
                                    i = computerHand.Count;
                                    cp = 2;
                                }
                            }
                        }

                    }
                    //Add try catch methods for every input
                     // Den num1 2 o 3 från value!!!!! LÖS DE FÖRFAN JÄVLA IDIOT EMIL!!!!!!
                    if (cp == 2)
                    {
                        //Find if there is any douplicates of cards
                        
                        // This is cursed
                        while (computerTry)
                        {
                            for (num1 = 0; num1 < computerHand.Count; num1++)
                            {
                                for (num2 = 0; num2 < computerHand.Count; num2++)
                                {
                                    if (num2 != num1)
                                    {
                                        //See if there are two cards
                                        if (cardValue[computerHand[num1]] == cardValue[computerHand[num2]])
                                        {
                                            compNum1 = num1;
                                            compNum2 = num2;
                                            cardCount = 2;
                                            computerTry = false;
                                        }
                                        else
                                        {
                                            if (num2 == computerHand.Count)
                                            {
                                                cardCount = 1;
                                                computerTry = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                        if (cardCount == 2)
                        {
                            Console.WriteLine("The computer asks for a " + compNum1 );
                            int j = 0;
                            for (int i = 0; i < hand.Count; i++)
                            {
                                if(cardValue[computerHand[compNum1 - 1]] == cardValue[hand[i]])
                                {
                                    //Put this into the UI
                                    Console.WriteLine("The computer takes all your " + compNum1);


                                    //Take from the players hand now
                                    int taker = hand[i];
                                    computerHand.Add(taker);
                                    hand.RemoveAt(i);

                                    computerAgain = true;
                                }
                                else
                                {
                                    j++;
                                    if (j == hand.Count)
                                    {
                                        computerAgain = false;
                                        cp = 1;
                                        i = hand.Count;
                                        
                                    }
                                }
                            }

                            if (computerAgain)
                            {
                                computerTry = true;
                                cardCount = 0;
                                num1 = 0;
                                num2 = 0;
                                num3 = 0;
                            }

                            //Stop with turning computerTry to true? and if you get some then put cp to 2 and if not then cp = 1
                        }

                        else
                        {
                            //randomise one number
                        }
                        ui(hand, computerHand, cardNum, cardValue, cardColour, cp, work);
                        Console.WriteLine(cardCount);


                        
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
        static void ui(List<int> hand, List<int> computerHand, List<int> cardNum, List<int> cardValue, List<string> cardColour, int cp, int work)
        {
            hand.Sort();
            computerHand.Sort();


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


            //For testing
            for (int i = 0; i < computerHand.Count; i++)
            {
                switch (cardValue[computerHand[i]])
                {
                    case 11:
                        Console.WriteLine((i + 1) + ") " + cardColour[computerHand[i]] + "  " + "Jack");
                        break;
                    case 12:
                        Console.WriteLine((i + 1) + ") " + cardColour[computerHand[i]] + "  " + "Queen");
                        break;
                    case 13:
                        Console.WriteLine((i + 1) + ") " + cardColour[computerHand[i]] + "  " + "King");
                        break;

                    default:
                        Console.WriteLine((i + 1) + ") " + cardColour[computerHand[i]] + "  " + cardValue[computerHand[i]]);
                        continue;
                }


            }



            Console.WriteLine("");
            Console.WriteLine("");
            if (cp == 1)
            {
                Console.WriteLine("Ask the computer for a card");
            }

            if (cp == 2)
            {
                Console.WriteLine("It's the computers turn");
            }

            if (work == 1)
            {
                Console.WriteLine("The computer had that card, it's your turn again.");
            }

            //Thread.Sleep(5000);


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

            while (go)
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

            while (go)
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


        //Test for getting three cards Computer
        /*
            for (num3 = 0; num3 < computerHand.Count; num3++)
                                            {
                                                //three cards
                                                if (num3 != num2 && num3 != num1 && num1 != num2)
                                                {
                                                    if (cardValue[computerHand[num3]] == cardValue[computerHand[num3]])
                                                    {
                                                        Console.WriteLine(cardValue[num1]);
                                                        Console.WriteLine(cardValue[num2]);
                                                        Console.WriteLine(cardValue[num3]);
                                                        cardCount = 3;
                                                        computerTry = false;
                                                    }
                                                }
                                                else
                                                {
                                                    if (num3 == computerHand.Count)
                                                    {
                                                        if (num1 == num2)
                                                        {
                                                            cardCount = 2;
                                                            computerTry = false;
                                                        }
                                                        else
                                                        {
                                                            cardCount = 1;
                                                            computerTry = false;
                                                        }

                                                    }
                                                }
                                                if (num3 == computerHand.Count)
                                                {
                                                    computerTry = false;
                                                }


                                            } 
        */


    }
}
