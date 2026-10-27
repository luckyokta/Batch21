Queue queue = new Queue();

queue.AddRule("urgent", 10);
queue.AddRule("normal", 5);

queue.Enqueue("normal");
queue.Enqueue("urgent");
queue.Enqueue("low");

queue.Process();
queue.Process();

class Queue
{
    List<(string val, int priority)> queue = new();

    Dictionary<string, int> rules = new();

    public void AddRule(string keyword, int priority)
    {
        rules[keyword] = priority;
    }

    public void Enqueue(string val)
    {
        int priority = rules.ContainsKey(val) ? rules[val] : 0;

        queue.Add((val, priority));

        Console.WriteLine($"Queued {val} with priority {priority}");
    }

    public void Process()
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