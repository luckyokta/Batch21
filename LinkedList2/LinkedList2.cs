// See https://aka.ms/new-console-template for more information
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

class Program
{
    static Node? head = null;
    static Node? tail = null;

    static void Main()
    {
        Append(5);
        Append(10);
        Append(15);
        Print();
        PrintReverse();
    }

    static void Append(int val)
    {
        Node newNode = new Node(val);

        if(head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.next = newNode;
            newNode.previous = tail;
            tail = newNode;
        }

        Console.WriteLine($"Appended {val}");
    }

    static void Print()
    {
        Node? current = head;
        Console.Write("Sequence: ");

        while(current != null)
        {
            Console.Write(current.val);

            if(current.next != null)
            {
                Console.Write(" -> ");
            }
            current = current.next;
        }

        Console.WriteLine();
    }

    static void PrintReverse()
    {
        Node? current = tail;
        Console.Write("Reversed: ");

        while(current != null)
        {
            Console.Write(current.val);

            if(current.previous != null)
            {
                Console.Write(" -> ");
            }

            current = current.previous;
        }

        Console.WriteLine();
    }
}