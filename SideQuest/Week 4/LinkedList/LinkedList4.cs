LinkedList myList = new();

myList.SetSorting((a, b) => a.CompareTo(b));
myList.AddFilter(x => x > 3);

myList.Append(5);
myList.Append(2);
myList.Append(1);
myList.Append(8);
myList.Append(10);

myList.Print();
myList.PrintReverse();


class Node
{
    public int val;
    public Node? next;
    public Node? previous;

    public Node(int val)
    {
        this.val = val;
        this.next = null;
        this.previous = null;
    }
}

class LinkedList
{
    private Node? head = null;
    private Node? tail = null;

    private Func<int, int, int>? comparer = null;
    private List<Func<int, bool>> filters = new();

    public void SetSorting(Func<int, int, int> comparer)
    {
        this.comparer = comparer;
    }

    public void AddFilter(Func<int, bool> filterRule)
    {
        filters.Add(filterRule);
    }

    public void Append(int val)
    {
        Node newNode = new Node(val);

        if(head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail!.next = newNode;
            newNode.previous = tail;
            tail = newNode;
        }

        Console.WriteLine($"Appended {val}");
    }

    public void Print()
    {
        List<int> values = new();

        Node? current = head;

        while(current != null)
        {
            bool passed = true;

            foreach(Func<int, bool> filter in filters)
            {
                if (!filter(current.val))
                {
                    passed = false;
                    break;
                }
            }

            if (passed)
            {
                values.Add(current.val);
            }

            current = current.next;
        }

        if(comparer != null)
        {
            values.Sort((a, b) => comparer(a, b));
        }

        Console.Write("Sequence: ");

        for(int i = 0; i < values.Count; i++)
        {
            Console.Write(values[i]);

            if(i < values.Count - 1)
            {
                Console.Write(" -> ");
            }
        }

        Console.WriteLine();
    }

    public void PrintReverse()
    {
        List<int> values = new();

        Node? current = head;

        while(current != null)
        {
            bool passed = true;

            foreach(Func<int, bool> filter in filters)
            {
                if (!filter(current.val))
                {
                    passed = false;
                    break;
                }
            }

            if (passed)
            {
                values.Add(current.val);
            }

            current = current.next;
        }

        if(comparer != null)
        {
            values.Sort((a, b) => comparer(a, b));
        }

        Console.Write("Reversed: ");

        for(int i = values.Count - 1; i >= 0; i--)
        {
            Console.Write(values[i]);

            if(i > 0)
            {
                Console.Write(" -> ");
            }
        }

        Console.WriteLine();
    }
}
