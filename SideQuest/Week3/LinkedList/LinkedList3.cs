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
        Insert(5);
        Insert(2);
        Insert(8);
        Print();
        PrintReverse();
    }

    static void Insert(int val)
    {
        Node newNode = new Node(val);

        if(head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else if(val < head.val)
        {
            newNode.next = head;
            head.previous = newNode;
            head = newNode;
        }
        else
        {
            Node current = head;

            while(current.next != null && current.next.val < val)
            {
                current = current.next;
            }

            newNode.next = current.next;
            newNode.previous = current;

            if(current.next != null)
            {
                current.next.previous = newNode;
            }
            else
            {
                tail = newNode;
            }

            current.next = newNode;
        }

        Console.WriteLine($"Inserted {val}");
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
