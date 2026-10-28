using System.Data;

History history = new History();

history.AddValidationRule(word => !string.IsNullOrWhiteSpace(word));
history.AddValidationRule(word => word.Length <= 10);

history.Type("hello");
history.Type("");
history.Type("hello hello");
history.Type("wow");
history.Undo();
history.Redo();

class History
{
    Stack<string> myStack = new();
    int maxHistory = 3;
    Stack<string> redoStack = new();

    List<Func<string, bool>> validationRules = new();

    public void AddValidationRule(Func<string, bool> rule)
    {
        validationRules.Add(rule);
    }

    public void Type(string word)
    {
        bool isValid = validationRules.All(rule => rule(word));

        if (!isValid)
        {
            Console.WriteLine($"Rejected {word}");
            return;
        }

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

    public void Undo()
    {
        string word = myStack.Pop();
        redoStack.Push(word);

        Console.WriteLine($"Undid {word}");
    }

    public void Redo()
    {
        string word = redoStack.Pop();
        myStack.Push(word);

        Console.WriteLine($"Redid {word}");
    }
}