using System.CodeDom.Compiler;

void Generate(int n)
{
    for(int i = 1; i <= n; i++)
    {
        if(i > 1)
        {
            Console.Write(", ");
        }

        if((i % 3 == 0) && (i % 5 == 0))
        {
            Console.Write("foobar");
        }
        else if (i % 3 == 0)
        {
            Console.Write("foo");
        }
        else if(i % 5 == 0)
        {
            Console.Write("bar");
        }
        else
        {
            Console.Write(i);
        }
    }
}

Generate(15);