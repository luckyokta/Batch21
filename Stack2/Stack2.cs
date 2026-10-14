// See https://aka.ms/new-console-template for more information
class Program
{
    static Stack<string> myStack = new Stack<string>();
    static int maxHistory = 3;

    static void Main()
    {
        Type("A");
        Type("B");
        Type("C");
        Type("D");
        Undo();
    }

    static void Type(string word)
    {
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
        Console.WriteLine($"Undid {word}");
    }
}