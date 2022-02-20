using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Matching_Game
{


    class Program
    {
      
        static void Main(string[] args)
        {
            bool loopgame = true;
            bool levelchoicegood = false;

            while (loopgame == true) 
            {
                Console.WriteLine();
                Console.Write("MEMORY GAME");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Choose difficulty:");
                Console.WriteLine();
                Console.WriteLine("Prees 1 for easy");
                Console.WriteLine("Press 2 for hard");
                Console.WriteLine();
                Console.WriteLine("and press enter");
                Console.WriteLine();
                Console.Write("Your choice: ");
                string level = Console.ReadLine();

                   if (level == "1")
                    {
                            levelchoicegood = true;
                            int chances = 10;
                            int usedchances = 0;
                            bool lost = false;
                            bool allwin = false;
                            int win = 0;
                            string tA0 = "X";
                            string tA1 = "X";
                            string tA2 = "X";
                            string tA3 = "X";
                            string tA4 = "X";
                            string tB1 = "X";
                            string tB2 = "X";
                            string tB3 = "X";
                            string tB4 = "X";


                            List<string> pos = new List<string>()
                             {tA0, tA1, tA2, tA3, tA4, tB1, tB2, tB3, tB4 };


                            List<string> listresult = File.ReadAllLines(@"Words.txt").ToList();

                            List<string> listrandompicked = new List<string>();

                            for (int i = 0; i < 4; i++)
                            {
                                Random random1 = new Random();
                                int index = random1.Next(listresult.Count);
                                listrandompicked.Add(listresult[index]);

                                if (i > 1 && listrandompicked[i] == listrandompicked[i - 1])
                                {
                                    listrandompicked.RemoveAt(listrandompicked.Count - 1);
                                    i--;
                                }
                            }

                            List<string> finalist = new List<string>();
                            finalist = listrandompicked.ToList();
                            finalist.AddRange(listrandompicked);

                            Random random2 = new Random();
                            var shufflelist = finalist.OrderBy(a => random2.Next()).ToList();

                            var timer = new Stopwatch();
                            timer.Start();

                            while (win < 4 && lost == false)
                            {

                                while (chances > 0)
                                {

                                    List<string> z = new List<string>()
                                     {
                                          "a0", "a1", "a2", "a3", "a4", "b1", "b2", "b3", "b4"
                                     };

                                    Console.Clear();
                                    Console.WriteLine("Tries left: " + chances);
                                    Console.WriteLine();
                                    Console.WriteLine("   |   1   |   2   |   3   |   4   ");
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" A |   " + pos[1] + "   |   " + pos[2] + "   |   " + pos[3] + "   |   " + pos[4]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" B |   " + pos[5] + "   |   " + pos[6] + "   |   " + pos[7] + "   |   " + pos[8]);
                                    Console.WriteLine();
                                    Console.WriteLine("Matched " + win + " of 4");
                                    Console.WriteLine();

                                    Console.Write("First choice (Write number of row, then number of column - no spaces): ");
                                    string firstchoice = Console.ReadLine();

                                    bool badfirstchoice = true;
                                    bool goodfirstchoice = true;
                                    int j = 0;

                                    while (badfirstchoice == true)
                                    {
                                        if (goodfirstchoice == true && badfirstchoice == true)
                                        {
                                            for (j = 1; j <= z.Count - 1; j++)

                                                if (firstchoice.ToLower() == z[j] && pos[j] == "X")
                                                {
                                                    pos[j] = shufflelist[j - 1];
                                                    badfirstchoice = false;
                                                    goodfirstchoice = true;
                                                    break;

                                                }

                                                else goodfirstchoice = false;
                                        }

                                        if (goodfirstchoice == false)
                                        {
                                            Console.Write("Wrong value, write again. (Write number of row, then number of column - no spaces: ");

                                            firstchoice = Console.ReadLine();
                                            goodfirstchoice = true;

                                        }

                                    }

                                    Console.Clear();
                                    Console.WriteLine("Pozostało prób: " + chances);
                                    Console.WriteLine();
                                    Console.WriteLine("   |   1   |   2   |   3   |   4   ");
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" A |   " + pos[1] + "   |   " + pos[2] + "   |   " + pos[3] + "   |   " + pos[4]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" B |   " + pos[5] + "   |   " + pos[6] + "   |   " + pos[7] + "   |   " + pos[8]);
                                    Console.WriteLine();
                                    Console.WriteLine("Matched " + win + " of 4");
                                    Console.WriteLine();

                                    Console.Write("Second choice (Write number of row, then number of column - no spaces: ");
                                    string secondchoice = Console.ReadLine();
                                    bool badsecondchoice = true;
                                    bool goodsecondchoice = true;
                                    int k = 0;

                                    while (badsecondchoice == true)
                                    {
                                        if (secondchoice.ToLower() == firstchoice.ToLower())
                                            goodsecondchoice = false;

                                        if (goodsecondchoice == true && badsecondchoice == true)
                                        {
                                            for (k = 1; k <= z.Count - 1; k++)

                                                if (secondchoice.ToLower() == z[k] && pos[k] == "X")
                                                {
                                                    pos[k] = shufflelist[k - 1];
                                                    badsecondchoice = false;
                                                    goodsecondchoice = true;
                                                    break;
                                                }

                                                else goodsecondchoice = false;
                                        }

                                        if (goodsecondchoice == false)
                                        {
                                            Console.Write("Wrong value, write again. (Write number of row, then number of column - no spaces: ");
                                            secondchoice = Console.ReadLine();
                                            goodsecondchoice = true;
                                        }

                                    }

                                    Console.Clear();
                                    Console.WriteLine("Tries left: " + chances);
                                    Console.WriteLine();
                                    Console.WriteLine("   |   1   |   2   |   3   |   4   ");
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" A |   " + pos[1] + "   |   " + pos[2] + "   |   " + pos[3] + "   |   " + pos[4]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" B |   " + pos[5] + "   |   " + pos[6] + "   |   " + pos[7] + "   |   " + pos[8]);
                                    Console.WriteLine();
                                    
                                    if (pos[j] != pos[k])
                                    {
                                        pos[j] = "X";
                                        pos[k] = "X";
                                        Thread.Sleep(1000);

                                    }

                                    else win++;

                                    chances--;
                                    Console.WriteLine("Matched " + win + " of 4");
                                    Console.WriteLine();
                                    Thread.Sleep(1000);

                            if (chances == 0)
                                    {
                                        lost = true;
                                        allwin = false;
                                    }

                                    if (chances == 0 && win == 4)
                                    {
                                        lost = false;
                                    }

                                    if (win == 4)
                                    {
                                        usedchances = (10 - chances);
                                        chances = 0;
                                        allwin = true;
                                    }

                                }

                                if (lost == true && allwin == false)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Out of chances! You lost!");
                                   // Console.ReadLine();
                                }

                            }

                            timer.Stop();

                            if (lost == false && allwin == true)
                            {
                                Console.Clear();
                                Console.WriteLine("You WIN! " + (usedchances) + " chances used.");
                                TimeSpan timeTaken = timer.Elapsed;
                                
                                Console.WriteLine("It took: " + timeTaken.ToString(@"m\:ss\.fff") + " seconds.");
                                
                            }
                            
                   }

                   else if (level == "2")
                   {
                            levelchoicegood = true;
                            int chances2 = 15;
                            int usedchances2 = 0;
                            bool lost2 = false;
                            bool allwin2 = false;
                            int win2 = 0;
                            string rA0 = "X";
                            string rA1 = "X";
                            string rA2 = "X";
                            string rA3 = "X";
                            string rA4 = "X";
                            string rB1 = "X";
                            string rB2 = "X";
                            string rB3 = "X";
                            string rB4 = "X";
                            string rC1 = "X";
                            string rC2 = "X";
                            string rC3 = "X";
                            string rC4 = "X";
                            string rD1 = "X";
                            string rD2 = "X";
                            string rD3 = "X";
                            string rD4 = "X";

                            List<string> pos2 = new List<string>()
                            {
                                rA0, rA1, rA2, rA3, rA4, rB1, rB2, rB3, rB4, rC1, rC2, rC3, rC4, rD1, rD2, rD3, rD4 
                            };

                            List<string> listresult2 = File.ReadAllLines(@"Words.txt").ToList();

                            List<string> listrandompicked2 = new List<string>();

                            for (int i = 0; i < 8; i++)
                            {
                                Random random3 = new Random();
                                int index = random3.Next(listresult2.Count);
                                listrandompicked2.Add(listresult2[index]);

                                if (i > 1 && listrandompicked2[i] == listrandompicked2[i - 1])
                                {
                                    listrandompicked2.RemoveAt(listrandompicked2.Count - 1);
                                    i--;
                                }

                            }

                            List<string> finalist2 = new List<string>();
                            finalist2 = listrandompicked2.ToList();
                            finalist2.AddRange(listrandompicked2);

                            Random random4 = new Random();
                            var shufflelist2 = finalist2.OrderBy(a => random4.Next()).ToList();

                            var timer2 = new Stopwatch();
                            timer2.Start();

                            while (win2 < 8 && lost2 == false)
                            {
                                while (chances2 > 0)
                                {
                                    List<string> z2 = new List<string>()
                                     {
                                        "a0", "a1", "a2", "a3", "a4", "b1", "b2", "b3", "b4", "c1", "c2", "c3", "c4", "d1", "d2", "d3", "d4"
                                     };


                                    Console.Clear();
                                    Console.WriteLine("Tries left: " + chances2);
                                    Console.WriteLine();
                                    Console.WriteLine("   |   1   |   2   |   3   |   4   ");
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" A |   " + pos2[1] + "   |   " + pos2[2] + "   |   " + pos2[3] + "   |   " + pos2[4]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" B |   " + pos2[5] + "   |   " + pos2[6] + "   |   " + pos2[7] + "   |   " + pos2[8]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" C |   " + pos2[9] + "   |   " + pos2[10] + "   |   " + pos2[11] + "   |   " + pos2[12]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" D |   " + pos2[13] + "   |   " + pos2[14] + "   |   " + pos2[15] + "   |   " + pos2[16]);

                                    Console.WriteLine();
                                    Console.WriteLine("Matched " + win2 + " of 8");
                                    Console.WriteLine();

                                    Console.Write("First choice (Write number of row, then number of column - no spaces): ");
                                    string firstchoice2 = Console.ReadLine();

                                    bool badfirstchoice2 = true;
                                    bool goodfirstchoice2 = true;
                                    int j2 = 0;

                                    while (badfirstchoice2 == true)
                                    {

                                        if (goodfirstchoice2 == true && badfirstchoice2 == true)
                                        {

                                            for (j2 = 1; j2 <= z2.Count - 1; j2++)

                                                if (firstchoice2.ToLower() == z2[j2] && pos2[j2] == "X")
                                                {
                                                    pos2[j2] = shufflelist2[j2 - 1];
                                                    badfirstchoice2 = false;
                                                    goodfirstchoice2 = true;
                                                    break;
                                                }

                                                else goodfirstchoice2 = false;

                                        }

                                        if (goodfirstchoice2 == false)
                                        {
                                            Console.Write("Wrong value, write again. (Write number of row, then number of column - no spaces: ");

                                            firstchoice2 = Console.ReadLine();
                                            goodfirstchoice2 = true;

                                        }

                                    }

                                    Console.Clear();
                                    Console.WriteLine("Tries left: " + chances2);
                                    Console.WriteLine();
                                    Console.WriteLine("   |   1   |   2   |   3   |   4   ");
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" A |   " + pos2[1] + "   |   " + pos2[2] + "   |   " + pos2[3] + "   |   " + pos2[4]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" B |   " + pos2[5] + "   |   " + pos2[6] + "   |   " + pos2[7] + "   |   " + pos2[8]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" C |   " + pos2[9] + "   |   " + pos2[10] + "   |   " + pos2[11] + "   |   " + pos2[12]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" D |   " + pos2[13] + "   |   " + pos2[14] + "   |   " + pos2[15] + "   |   " + pos2[16]);

                                    Console.WriteLine();
                                    Console.WriteLine("Matched " + win2 + " of 8");
                                    Console.WriteLine();

                                    Console.Write("Second choice (Write number of row, then number of column - no spaces: ");
                                    string secondchoice2 = Console.ReadLine();
                                    bool badsecondchoice2 = true;
                                    bool goodsecondchoice2 = true;
                                    int k2 = 0;

                                    while (badsecondchoice2 == true)
                                    {
                                        if (secondchoice2.ToLower() == firstchoice2.ToLower())
                                            goodsecondchoice2 = false;

                                        if (goodsecondchoice2 == true && badsecondchoice2 == true)
                                        {
                                            for (k2 = 1; k2 <= z2.Count - 1; k2++)

                                                if (secondchoice2.ToLower() == z2[k2] && pos2[k2] == "X")
                                                {
                                                    pos2[k2] = shufflelist2[k2 - 1];
                                                    badsecondchoice2 = false;
                                                    goodsecondchoice2 = true;
                                                    break;
                                                }
                                                else goodsecondchoice2 = false;

                                        }

                                        if (goodsecondchoice2 == false)
                                        {
                                            Console.Write("Wrong value, write again. (Write number of row, then number of column - no spaces: ");
                                            secondchoice2 = Console.ReadLine();
                                            goodsecondchoice2 = true;

                                        }

                                    }

                                    Console.Clear();
                                    Console.WriteLine("Tries left: " + chances2);
                                    Console.WriteLine();
                                    Console.WriteLine("   |   1   |   2   |   3   |   4   ");
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" A |   " + pos2[1] + "   |   " + pos2[2] + "   |   " + pos2[3] + "   |   " + pos2[4]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" B |   " + pos2[5] + "   |   " + pos2[6] + "   |   " + pos2[7] + "   |   " + pos2[8]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" C |   " + pos2[9] + "   |   " + pos2[10] + "   |   " + pos2[11] + "   |   " + pos2[12]);
                                    Console.WriteLine("---|-------|-------|-------|-------");
                                    Console.WriteLine(" D |   " + pos2[13] + "   |   " + pos2[14] + "   |   " + pos2[15] + "   |   " + pos2[16]);
                                    Console.WriteLine();
                                    
                                    if (pos2[j2] != pos2[k2])
                                    {
                                        pos2[j2] = "X";
                                        pos2[k2] = "X";
                                        Thread.Sleep(1000);

                                    }

                                    else win2++;

                                    chances2--;

                                    Console.WriteLine("Matched " + win2 + " of 8");
                                    Console.WriteLine();
                                    Thread.Sleep(1000);

                            if (chances2 == 0)
                                    {
                                        lost2 = true;
                                        allwin2 = false;

                                    }

                                    if (chances2 == 0 && win2 == 8)
                                    {
                                        lost2 = false;

                                    }

                                    if (win2 == 8)
                                    {
                                        usedchances2 = (15 - chances2);
                                        chances2 = 0;
                                        allwin2 = true;

                                    }

                                }

                                if (lost2 == true && allwin2 == false)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Out of chances! You lost!");
                                   
                                }

                            }

                            timer2.Stop();

                            if (lost2 == false && allwin2 == true)
                            {
                                Console.Clear();
                                Console.WriteLine("You WIN! " + (usedchances2) + " chances used.");
                                TimeSpan timeTaken2 = timer2.Elapsed;
                                Console.WriteLine("It took: " + timeTaken2.ToString(@"m\:ss\.fff") + " seconds.");


                            }     

                   }

                   else
                   {
                          levelchoicegood = false;

                   }

                   if (levelchoicegood == true)
                   {
                        bool goodrepeat = false;

                        while (goodrepeat == false)
                        {
                            Thread.Sleep(2000);
                            Console.WriteLine();
                            Console.WriteLine("Want to play again?");
                            Console.WriteLine();
                            Console.WriteLine("Prees y for yes.");
                            Console.WriteLine("Press n to exit.");
                            Console.WriteLine();
                            Console.WriteLine("and press enter");
                            Console.WriteLine();
                            Console.Write("Your choice: ");

                            string repeat = Console.ReadLine();
                            repeat = repeat.ToLower();


                            if (repeat == "y")
                            {
                                goodrepeat = true;
                                loopgame = true;
                                Console.Clear();
                            
                            }

                            else if (repeat == "n")
                            {
                                goodrepeat = true;
                                loopgame = false;
                                Console.Clear();
                   
                            }
                     
                            else
                            {
                                goodrepeat = false;
                                Console.Clear();
                                Console.WriteLine("Wrong choice, Try Again");

                            }

                        }
                    
                   }

                   else
                   {
                        Console.Clear();
                        Console.WriteLine("Wrong choice, Try Again");

                   }

            }

        }

    }

}