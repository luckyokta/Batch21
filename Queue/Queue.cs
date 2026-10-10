// See https://aka.ms/new-console-template for more information
class Program
{
    static Queue<string> queue = new Queue<string>();
    static void Main()
    {
        Enqueue("A");
        Enqueue("B");
        Process();
        Process();
    }
    static void Enqueue(string val)
    {
        queue.Enqueue(val);
        Console.WriteLine($"Queued {val}");
    }
    static void Process()
    {
        if(queue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
        }
        else
        {
            string val = queue.Dequeue();
            Console.WriteLine($"Processed {val}");
        }
    }
}