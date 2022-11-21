using System;
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
                    + "\n4. CheckParanthesis"
                    + "\n5. Recursive Fibonacci"
                    + "\n6. Iterative Fibonacci"
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
                        IterativeFibonacci(10);
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
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

            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);
            //theList.Add(value);

            //switch(nav){...}
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
                        string namePlusMinus = Console.ReadLine();
                                                               
                        if (namePlusMinus.StartsWith("+"))
                        {
                            string name = namePlusMinus.Substring(1).ToUpper();
                            if (name == "")
                            {
                                name = "HARRY";
                                theList.Add(name);
                            }
                            else
                            {
                                theList.Add(name);
                            }
                            PrintList(theList);
                            break;
                        }
                        if (namePlusMinus.StartsWith("-"))
                        {
                            string name = namePlusMinus.Substring(1).ToUpper();
                            if (name == "")
                            {
                                theList.RemoveAt(0);
                            }
                            else
                            {
                                if (theList != null)
                                    theList.Remove(name);
                            }
                            PrintList(theList);
                            break;
                        }
                     
                        Console.WriteLine("\n   *** You have to write at least + or - as input ***\n +" +
                            "nothing got added");

                        PrintList(theList);
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
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
                    + "\n2. Tack för besöket - hoppas godiset är gott :)"
                    + "\n3. När är det min tur?"
                    //+ "\n4. just -"
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
                        string name = Console.ReadLine();
                        //string value = input.substring(1);
                        if (name.Length == 0)
                            name = "harry";
                        theQue.Enqueue($"{name} - tar det lång tid?");

                        foreach (var item in theQue)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine(theQue.Count);
                        //Tess();
                        //Console.WriteLine(theQue.Capacity);
                        Console.WriteLine();
                        break;
                    case '2':
                        if (theQue.Count() == 0)
                            Console.WriteLine("Du är först i kön :)");
                        break;
                        theQue.Dequeue();
                        Console.WriteLine(theQue.Count);
                        //Console.WriteLine(theQue.Capacity);
                        Console.WriteLine();
                        break;
                    case '3':
                        theQue.Peek();
                        Console.WriteLine("{0} Det blir strax din tur", theQue.Peek());
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
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
            string drow = "";
            Console.WriteLine("\nHej skriv in ett valfritt ord.");
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
                        string word = Console.ReadLine();
                        for (int i = 0; i < word.Length; i++)
                        {
                            stack.Push(word[i]);
                        }
                        drow = String.Join("", stack.ToArray());
                        Console.WriteLine();
                        Console.WriteLine(drow);
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

                        string inputParenthesis = Console.ReadLine();
                        char[] stringToChar = inputParenthesis.ToCharArray();

                        for (int i = 0; i < stringToChar.Length; i++)
                        {
                            if (stringToChar.Contains('(') || stringToChar.Contains('{') || stringToChar.Contains('['))
                            {
                                parStack.Push(stringToChar[0]);
                            }
                            if (parStack.Peek() == '(' && stringToChar.Contains(')') || (parStack.Peek() == '{' && stringToChar.Contains('}') || (parStack.Peek() == '[' && stringToChar.Contains(']'))))
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
            Console.Write(n);
            
            Console.ReadLine();
            return (RecursiveEven(n - 2) + 2);
        }
      
        static void IterativeFibonacci(int n){
            
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

