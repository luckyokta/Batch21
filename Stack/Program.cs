// See https://aka.ms/new-console-template for more information
class Program
{
    static Stack<string> myStack = new Stack<string>();

    static void Main()
    {
        Type("foo");
        Type("bar");
        Undo();
        Undo();
    }

    static void Type(string word)
    {
        myStack.Push(word);
        Console.WriteLine($"Typed {word}");
    }
    static void Undo()
    {
        string word = myStack.Pop();
        Console.WriteLine($"Undid {word}");
    }
}
