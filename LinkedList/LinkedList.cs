class Node
{
    public int val;
    public Node next;

    public Node(int val)
    {
        this.val = val;
        this.next = null;
    }
}
class Program
{
    static Node head = null;
    static void Main()
    {
        Append(5);
        Append(10);
        Print();
    }

    static void Append(int val)
    {
        Node newNode = new Node(val);

        if(head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;

            while(current.next != null)
            {
                current = current.next;
            }

            current.next = newNode;
        }

        Console.WriteLine($"Appended {val}");
    }

    static void Print()
    {
        Node current = head;
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
    }
}