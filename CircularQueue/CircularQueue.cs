class Program
{
    static int capacity = 3;
    static int[] buffer = new int[capacity];
    static int front = 0;
    static int count = 0;
    static int rear = 0;

    static void Main()
    {
        Log(1);
        Log(2);
        Log(3);
        Log(4);
        Read();
    }
    
    static void Log(int val)
    {
        if(count == capacity)
        {
            Console.WriteLine("Buffer Full");
            return;
        }

        buffer[rear] = val;
        rear = (rear + 1) % capacity;
        count++;

        Console.WriteLine($"Logged {val}");
    }

    static void Read()
    {
        if(count == 0)
            return;

        int val = buffer[front];
        front = (front + 1) % capacity;
        count--;

        Console.WriteLine($"Read {val}");
    }
}