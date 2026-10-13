// See https://aka.ms/new-console-template for more information
class Queue
{
    static List<string> queue = new List<string>();
    static void Main()
    {
        Enqueue("A");
        Enqueue("B");
        EnqueueVip("C");
        Process();
        Process();
        Process();
    }

    static void Enqueue(string val)
    {
        queue.Add(val);
        Console.WriteLine($"Queued {val}");
    }

    static void EnqueueVip(string val)
    {
        queue.Insert(0, val);
        Console.WriteLine($"VIP Queued {val}");
    }

    static void Process()
    {
        if(queue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
        }
        else
        {
            string val = queue[0];
            queue.RemoveAt(0);
            Console.WriteLine($"Processed {val}");
        }
    }
}