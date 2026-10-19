// See https://aka.ms/new-console-template for more information
class Queue
{
    static List<(string val, int priority)> queue = new();
    static void Main()
    {
        Enqueue("A", 1);
        Enqueue("B", 5);
        Enqueue("C", 5);
        Process();
        Process();
    }

    static void Enqueue(string val, int priority)
    {
        queue.Add((val, priority));
        Console.WriteLine($"Queued {val} with priority {priority}");
    }

    static void Process()
    {
        if(queue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
        }
        else
        {
            int index = 0;

            for(int i = 1; i < queue.Count; i++)
            {
                if(queue[i].priority > queue[index].priority)
                {
                    index = i;
                }
            }
            
            string val = queue[index].val;
            queue.RemoveAt(index);
            Console.WriteLine($"Processed {val}");
        }
    }
}
