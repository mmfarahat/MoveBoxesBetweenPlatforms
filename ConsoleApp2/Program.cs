using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{

    public static string[] Solve(int[] boxesA, int[] boxesB, int[] boxesC)
    {
        // Write your code here
        // To debug: Console.Error.WriteLine("Debug messages...");

        var boxesAStack = new Stack<int>(boxesA);
        var boxesBStack = new Stack<int>(boxesB);
        var boxesCStack = new Stack<int>(boxesC);
        var max = GetMax(boxesAStack, boxesBStack, boxesCStack);
        List<string> moves = new List<string>();

        //clean A
        while (boxesAStack.Count > 0)
        {
            if (boxesAStack.Count == 1 && boxesAStack.Peek() == max)
            {
                break;
            }
            moves.Add("A B");
            int popedItem = boxesAStack.Pop();
            boxesBStack.Push(popedItem);


        }





        while (boxesBStack.Any() || boxesCStack.Any())
        {
            max = GetMax(new Stack<int>(), boxesBStack, boxesCStack);
            if (max > 0)
            {
                if (boxesBStack.Any() && boxesBStack.Contains(max))
                {

                    {
                        if (boxesBStack.Peek() != max)
                        {
                            int popedItem = boxesBStack.Pop();
                            boxesCStack.Push(popedItem);
                            moves.Add("B C");

                        }
                        else
                        {
                            int popedItem = boxesBStack.Pop();
                            boxesAStack.Push(popedItem);
                            moves.Add("B A");
                        }
                    }

                }
                else if (boxesCStack.Any() && boxesCStack.Contains(max))
                {

                    if (boxesCStack.Peek() != max)
                    {
                        int popedItem = boxesCStack.Pop();
                        boxesBStack.Push(popedItem);
                        moves.Add("C B");

                    }
                    else
                    {
                        int popedItem = boxesCStack.Pop();
                        boxesAStack.Push(popedItem);
                        moves.Add("C A");
                    }

                }

            }

        }
        return moves.ToArray();
    }

    static int GetMax(Stack<int> boxesA, Stack<int> boxesB, Stack<int> boxesC)
    {
        int max = 0;
        if (boxesA.Any())
        {
            max = boxesA.Max();
        }
        if (boxesB.Any() && boxesB.Max() > max)
        {
            max = boxesB.Max();
        }
        if (boxesC.Any() && boxesC.Max() > max)
        {
            max = boxesC.Max();
        }



        return max;
    }



    /* Ignore and do not change the code below */
    #region
    static void Main(string[] args)
    {
        //string[] inputs;
        //int boxesCountA = int.Parse(Console.ReadLine());
        //int[] boxesA = new int[boxesCountA];
        //inputs = Console.ReadLine().Split(' ');
        //for (int i = 0; i < boxesCountA; i++)
        //{
        //    boxesA[i] = int.Parse(inputs[i]);
        //}
        //int boxesCountB = int.Parse(Console.ReadLine());
        //int[] boxesB = new int[boxesCountB];
        //inputs = Console.ReadLine().Split(' ');
        //for (int i = 0; i < boxesCountB; i++)
        //{
        //    boxesB[i] = int.Parse(inputs[i]);
        //}
        //int boxesCountC = int.Parse(Console.ReadLine());
        //int[] boxesC = new int[boxesCountC];
        //inputs = Console.ReadLine().Split(' ');
        //for (int i = 0; i < boxesCountC; i++)
        //{
        //    boxesC[i] = int.Parse(inputs[i]);
        //}
        var stdtoutWriter = Console.Out;
        //Console.SetOut(Console.Error);
        int[] boxesA = new int[1] { 66 };
        int[] boxesB = new int[1] { 20 };
        int[] boxesC = new int[1] { 30 };
        string[] actions = Solve(boxesA, boxesB, boxesC);
        Console.SetOut(stdtoutWriter);
        for (int i = 0; i < actions.GetLength(0); i++)
        {
            Console.WriteLine(actions[i]);
        }
    }
    #endregion
}