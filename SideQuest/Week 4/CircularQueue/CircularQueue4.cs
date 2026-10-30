class Program
{
    static void Main()
    {
        try
        {
            CircularQueue circularQueue = new CircularQueue();

            circularQueue.SetCapacity(3);
            circularQueue.SetOverwritePolicy(true);

            circularQueue.Log(1);
            circularQueue.Log(2);
            circularQueue.Log(3);
            circularQueue.Log(4);

            circularQueue.Read();
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Invalid capacity: {ex.Message}");
        }
    }
}

class CircularQueue
{
    private int capacity;
    private int[] buffer = null!;
    private int front;
    private int count;
    private int rear;
    private const double WarningThreshold = 0.66;
    private bool overwriteEnabled;

    public CircularQueue(int capacity = 3)
    {
        SetCapacity(capacity);
    }

    public void SetCapacity(int n)
    {
        if(n <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Capacity must be greater than zero.");
        }

        capacity = n;
        buffer = new int[capacity];

        front = 0;
        rear = 0;
        count = 0;
    }

    public void SetOverwritePolicy(bool isOverwriteEnabled)
    {
        overwriteEnabled = isOverwriteEnabled;
    }
    
    public void Log(int val)
    {
        if(count == capacity)
        {
            Console.WriteLine("Critical: Buffer Full");
            if (overwriteEnabled)
            {
                buffer[rear] = val;
                rear = (rear + 1) % capacity;
                front = (front + 1) % capacity;

                Console.WriteLine($"Overwritten oldest with {val}");
            }
            else
            {
                Console.WriteLine($"Buffer Full. Rejected {val}.");
            }

            return;
        }

        if((double)count / capacity >= WarningThreshold)
        {
            Console.WriteLine("Warning: Buffer at 66%");
        }

        buffer[rear] = val;
        rear = (rear + 1) % capacity;
        count++;

        Console.WriteLine($"Logged {val}");
    }

    public void Read()
    {
        if(count == 0)
            return;

        int val = buffer[front];
        front = (front + 1) % capacity;
        count--;

        Console.WriteLine($"Read {val}");
    }
}
