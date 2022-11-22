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
                        // Ifall inputsträngen startar med "+".
                        if (namePlusMinus.StartsWith("+"))
                        {   // Använder nästkommande del i strängen och gör dem till stora bokstäver.
                            string name = namePlusMinus.Substring(1).ToUpper();
                            // Fall strängen endast är ett + läggs namnet HARRY till som default.
                            if (name == "")
                            {
                                name = "HARRY";
                                theList!.Add(name);
                            }
                            // Annars läggs resten av strängen till.
                            else
                            {
                                theList!.Add(name);
                            }
                            // Sedan printas hela listan ut.
                            PrintList(theList);
                            break;
                        }
                        // I det fall strängen startar med "-".
                        if (namePlusMinus.StartsWith("-"))
                        {   // Använder nästa del i strängen och gör strängen till stora bokstäver.
                            string name = namePlusMinus.Substring(1).ToUpper();
                            // I det fall listan är tom, påtalas det i konsolen.
                            if (theList.Count == 0)
                            {
                                Console.WriteLine("Det verkar som listan redan är tom, prova att lägg till ett namn.");
                                
                            }
                            // i det fall strängen ej är tom, söks namnet på den sträng som skall tas bort.
                            else if (name.Length > 0 && theList.Contains(name))
                            {
                                theList.Remove(name);
                            }
                            // Om namnet inte finns men den ändå är populerad tas det första "namnet" bort (utifrån instruktioner om att man skulle kunna använda endast ett "-". 
                            else 
                            {
                                theList!.RemoveAt(0);
                                //if (theList != null)
                            }
                            // Den nya versionen av listan printas ut.
                            PrintList(theList!);
                            break;
                        }
                        // Felmeddelande fall användaren endast returnerar - utan att skriva något.
                        Console.WriteLine("\n   *** You have to write at least + or - as input, else nothing gets added ***");
                        // Här printas listan ut igen i det fall det inte lagts in något - den aktuella iterationenen.
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
            // Funktion för att printa listan innehåll genom foreach - tillsammans med Count och Capacity.
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
            // Deklaration och instansiering av en array, cirkulär (Ica kön).
            // LIFO Last in First out principen.
            Queue<string> theQue = new Queue<string>();
            while (true)
            {
                Console.WriteLine("Hej och välkommen till Ica \n"
                    + "\n1. Ställ dig i kön."
                    + "\n2. Expediering av en kund."
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
                        // Gör så att prompten är på samma rad och väntar på input.
                        Console.Write("Skriv in namn: ");
                        string name = Console.ReadLine()!;
                        Console.WriteLine();
                        // Fall anv endast returnerar, läggs Harry till i kön.                       
                        if (name.Length == 0)
                            name = "Harry";
                        // Namnet läggs läggs till i listan.
                        theQue!.Enqueue(name);
                        // Och får en hälsning.
                        Console.WriteLine($"Hej {name}!");
                        break;
                    case '2':
                        // Fall kön är tom, påtalas detta.
                        if (theQue!.Count() == 0)
                        {
                            Console.WriteLine("Kön verkar tom");
                            break;
                        }
                        // Annars tackas "personen" som är först i kön. 
                        Console.WriteLine($"tack för besöket {theQue.Peek()} - Välkommen åter!");
                        // Och avlägsnas från listan.
                        theQue.Dequeue();
                        // Kön printas ut igen.
                        PrintQue(theQue);
                        break;
                    case '3':
                        // Här kan man kolla på kön - fall den är tom.
                        if (theQue.Count() == 0)
                        {
                            Console.WriteLine("Kön verkar tom");
                        }
                        else // Annars visas "vem", vad som är "högst upp" i kön. 
                            Console.WriteLine("{0} Det blir strax din tur", theQue.Peek());
                        // Kön printas.
                        PrintQue(theQue);
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3)");
                        break;
                }
            }// Funktionen / Metoden som printar kön.
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
            // Stack elementet initieras
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
                        // Input av sträng, som skall presenteras baklänges.
                        Console.Write("Skriv in här: ");
                        string word = Console.ReadLine()!;
                            // Forloopen som 
                            for (int i = 0; i < word.Length; i++)
                        {       // pushar boktsäverna på stacken.
                                stack.Push(word[i]);
                            }
                        // Samtidigt som de nya elementen skrivs ut blir dem en string ifrån tidigare array.
                        Console.WriteLine(String.Join("", stack.ToArray()));
                        // Elementet "rensas" i det fall man vill prova en andra gång.
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
            // Deklaration samt initiering av - enligt uppgiftens instruktioner - ett valfritt alternativ, stack. 
            Stack<char> parStack = new Stack<char>();
            // Stacken fylls på med ett element inför kommande loop.
            parStack.Push('µ');
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
                        // Input av strängen med paranteser
                        Console.Write("Skriv in parantessträngen: ");
                        string inputParenthesis = Console.ReadLine()!;
                        // Här görs strängen till en array bestående av typen char
                        char[] stringToChar = inputParenthesis.ToCharArray();
                        // loop för att bedöma vilka tecken som arrayenbestår av
                        for (int i = 0; i < stringToChar.Length; i++)
                        {   // Villkoren för vilka tecken 
                            if (stringToChar.Contains('(') || stringToChar.Contains('{') || stringToChar.Contains('['))
                            {   // som skall pushas på stacken.
                                parStack.Push(stringToChar[0]);
                            }   // Dem tecken som återfinns i stacken nu jämförs för paritet och
                            if (parStack.Peek() == '(' && stringToChar.Contains(')') || (parStack.Peek() == '{' && 
                                stringToChar.Contains('}') || (parStack.Peek() == '[' && stringToChar.Contains(']'))))
                            {   // avlägsnas då från stacken.
                                parStack.Pop();
                            }

                        }
                        // Här kollas fall det endast är ett initieringstecken kvar -
                        // vilket kommer spricka fall användaren skriver in det tecknet -
                        // skall fråga er hur man på bästa sätt skulle kunna lösa detta utan ett tecken.
                        if (parStack.Count == 1)
                        {   // Printar fall det var en jämn uppsättning paranteser.
                            Console.WriteLine("Det finns en balans!");
                            break;
                        }
                        else
                        {   // Annars inte
                            Console.WriteLine("No balance!");
                            break;
                        }
                    case '2':
                        // Här skriver anv in önskat antal för den rekursiva Fibonacci sekvensen
                        Console.Write("Skriv önskat antal för Fibonaccisekvensen: ");
                        string answer = Console.ReadLine()!;
                        // Strängen görs om till en int
                        int antal =Int32.Parse(answer);
                        // loppen aanvänds för att printa ut varje nummer i sekvensen
                        for (int i = 0; i < antal; i++)
                        {   // här nere.
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
        // Den rekursiva metoden som ger jämnt resultat.
        static int RecursiveEven(int n)
        {
            if (n == 2)
            {
                return 2;
            }
            Console.Write(n +" ");

            return (RecursiveEven(n - 2) + 2);
        }
        // Den rekursiva metoden för Fibonacci.
        static int RecursiveFibonacci(int n)
        {   
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
            {   // Här räknas och adderas varsit "träd" el gren kanske blir mer rätt.          
                return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
            }

        }
        // En iterationsloop för ett resultat med jämna nummer.
        static void IterativeEven(int n)
        {   // Variabel deklarareras samt initieras för att
            // printa ut resultatet.
            int result = 0;

            for (int i = 0; i < n; i++)
            {   // Här ökar resultat jämnt
                result += 2;
                // och printas ut.
                Console.Write(result + " ");
            }
        }
        // Den iterativa versionen av Fibonacci.
        static void IterativeFibonacci(int n)
        {
            // variablerna deklareras och initieras.
            int a = 0;
            int b = 0;
            int c = 1;
            // och i loopen med base caset 
            while (a < n)
            {
                a += 1;
                // printas resultatet ut.
                Console.Write(b + " ");
                // Här sparas resultatet
                // samt förberads för nästa iteration.
                int between = b;
                b = c;
                c = between + c;
            }
            Console.ReadLine();
        }

    }
}

