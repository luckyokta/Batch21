// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

class Program
{
    static Stack<string> myStack = new Stack<string>();
    static int maxHistory = 3;
    static Stack<string> redoStack = new Stack<string>();

    static void Main()
    {
        Type("A");
        Type("B");
        Undo();
        Redo();
    }

    static void Type(string word)
    {
        redoStack.Clear();

        if(myStack.Count >= maxHistory)
        {
            Stack<string> temp = new Stack<string>();

            while(myStack.Count > 1)
            {
                temp.Push(myStack.Pop());
            }

            myStack.Pop();

            while(temp.Count > 0)
            {
                myStack.Push(temp.Pop());
            }

            myStack.Push(word);
            Console.WriteLine($"Dropped bottom, Typed {word}");
        }
        else
        {
            myStack.Push(word);
            Console.WriteLine($"Typed {word}");
        }
    }

    static void Undo()
    {
        string word = myStack.Pop();
        redoStack.Push(word);

        Console.WriteLine($"Undid {word}");
    }

    static void Redo()
    {
        string word = redoStack.Pop();
        myStack.Push(word);
        Console.WriteLine($"Redid {word}");
    }
}
