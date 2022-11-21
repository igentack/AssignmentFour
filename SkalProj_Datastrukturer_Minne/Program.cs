﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {

        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3, 4, 5, 6, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Turn around a word"
                    + "\n4. CheckParanthesis OR try a recursive Fibonacci sequence"
                    + "\n5. Recursive Even"
                    + "\n6. Iterative Even"
                    + "\n7. Iterative Fibonacci"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        RecursiveEven(10);
                        break;
                    case '6':
                        IterativeEven(10);
                        break;
                    case '7':
                        IterativeFibonacci(10);
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5, 6)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {

            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            // Här deklarerar och instansierar jag listan.
            List<string> theList = new List<string>();
            while (true)
            {
                Console.WriteLine("Hej skriv (+ el -) tillsammans med ett namn \neller bara + el -\n"
                    + "\n1. Prova"
                    + "\n0. Avsluta");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some Value!");
                }
                switch (input)
                {
                    case '1':
                        Console.Write("Skriv in namn (alternativt bara '+' el. '-' ) här: ");
                        string namePlusMinus = Console.ReadLine()!;
                        // Ifall inputsträngen startar med +
                        if (namePlusMinus.StartsWith("+"))
                        {   // Använder nästkommande del i strängen och gör dem till stora bokstäver
                            string name = namePlusMinus.Substring(1).ToUpper();
                            // Fall strängen endast är ett + läggs namnet HARRY till som default
                            if (name == "")
                            {
                                name = "HARRY";
                                theList!.Add(name);
                            }
                            // Annars läggs resten av strängen till
                            else
                            {
                                theList!.Add(name);
                            }
                            // Sedan printas hela listan ut
                            PrintList(theList);
                            break;
                        }
                        if (namePlusMinus.StartsWith("-"))
                        {
                            string name = namePlusMinus.Substring(1).ToUpper();
                            if (name == "")
                            {
                                theList!.RemoveAt(0);
                            }
                            else
                            {
                                if (theList != null)
                                    theList.Remove(name);
                            }
                            PrintList(theList!);
                            break;
                        }

                        Console.WriteLine("\n   *** You have to write at least + or - as input, else nothing gets added ***");

                        PrintList(theList!);
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1)");
                        break;
                }
            }
            static void PrintList(List<string> theList)
            {
                foreach (var item in theList)
                {
                    Console.WriteLine($"Namn:\t {item}");
                }
                Console.WriteLine($"Medlemmar i listan:\t{theList.Count}\n" +
                                  $"Listans kapacitet:\t{theList.Capacity}\n");
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQue = new Queue<string>();
            while (true)
            {
                Console.WriteLine("Hej och välkommen till Ica \n"
                    + "\n1. Ställ dig i kön."
                    + "\n2. Expidiering av en kund."
                    + "\n3. Se kön."
                    + "\n0. Exit");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        Console.Write("Skriv in namn: ");
                        string name = Console.ReadLine()!;
                        Console.WriteLine();
                        if (name.Length == 0)
                            name = "Harry";

                        theQue!.Enqueue(name);
                        Console.WriteLine($"Hej {name}!");
                        break;
                    case '2':
                        if (theQue!.Count() == 0)
                        {
                            Console.WriteLine("Kön verkar tom");
                            break;
                        }

                        Console.WriteLine($"tack för besöket {theQue.Peek()} - Välkommen åter!");
                        theQue.Dequeue();
                        PrintQue(theQue);
                        break;
                    case '3':
                        if (theQue.Count() == 0)
                        {
                            Console.WriteLine("Kön verkar tom");
                        }
                        else
                            Console.WriteLine("{0} Det blir strax din tur", theQue.Peek());
                        PrintQue(theQue);
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                        break;
                }
            }
            static void PrintQue(Queue<string> theQue)
            {
                Console.WriteLine();
                foreach (var item in theQue)
                {
                    Console.WriteLine($"\t{item}");
                }
                Console.WriteLine($"\n\tAntal kunder: {theQue.Count}\n");
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack stack = new Stack();
            Console.WriteLine("\nVända på ord.");
            while (true)
            {
                Console.WriteLine(""
                    + "\n1. Välj ett ord"
                    + "\n0. Tillbaka till huvudmenyn");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        Console.Write("Skriv in här: ");
                        string word = Console.ReadLine()!;
                        
                            for (int i = 0; i < word.Length; i++)
                            {
                                stack.Push(word[i]);
                            }

                        Console.WriteLine(String.Join("", stack.ToArray()));
                        stack.Clear();

                        break;
                    case '0':
                        Main();
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1)");
                        break;
                }
            }
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Stack<char> parStack = new Stack<char>();
            parStack.Push('*');
            Console.WriteLine("\nVälformade paranteser?");
            while (true)
            {
                Console.WriteLine(""
                    + "\n1. Prova"
                    + "\n2. Eller varför inte prova en rekursiv Fibonacci sekvens?"
                    + "\n0. Tillbaka till huvudmenyn");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                //object paramInput = null;
                switch (input)
                {
                    case '1':
                        Console.Write("Skriv in parantessträngen: ");

                        string inputParenthesis = Console.ReadLine()!;
                        char[] stringToChar = inputParenthesis.ToCharArray();

                        for (int i = 0; i < stringToChar.Length; i++)
                        {
                            if (stringToChar.Contains('(') || stringToChar.Contains('{') || stringToChar.Contains('['))
                            {
                                parStack.Push(stringToChar[0]);
                            }
                            if (parStack.Peek() == '(' && stringToChar.Contains(')') || (parStack.Peek() == '{' && 
                                stringToChar.Contains('}') || (parStack.Peek() == '[' && stringToChar.Contains(']'))))
                            {
                                parStack.Pop();
                            }

                        }
                        if (parStack.Count == 1)
                        {
                            Console.WriteLine("Det finns en balans!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No balance!");
                            break;
                        }
                    case '2':
                        Console.Write("Skriv önskat antal för Fibonaccisekvensen: ");
                        string answer = Console.ReadLine()!;
                        int antal =Int32.Parse(answer);

                        for (int i = 0; i < antal; i++)
                        {
                            Console.Write(RecursiveFibonacci(i) + " ");
                        }
                        break;
                    case '0':
                        Main();
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }
        static int RecursiveEven(int n)
        {
            if (n == 2)
            {
                return 2;
            }
            Console.Write(n +" ");

            return (RecursiveEven(n - 2) + 2);
        }

        static int RecursiveFibonacci(int n)
        {   
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {            
                return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
            }

        }

        static void IterativeEven(int n)
        {
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                result += 2;
                Console.Write(result + " ");
            }
        }

        static void IterativeFibonacci(int n)
        {

            int a = 0;
            int b = 0;
            int c = 1;

            while (a < n)
            {
                a += 1;

                Console.Write(b + " ");

                int between = b;
                b = c;
                c = between + c;
            }
            Console.ReadLine();
        }

    }
}

