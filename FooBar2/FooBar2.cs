// See https://aka.ms/new-console-template for more information
void Generate(int n)
{ 
    for(int i = 1; i <= n; i++)
    {
        string result = "";
        
        if(i > 1)
        {
            Console.Write(", ");
        }

        if (i % 3 == 0)
        {
            result += "foo";
        }
        if(i % 5 == 0)
        {
            result += "bar";
        }
        if(i % 7 == 0)
        {
            result += "jazz";
        }
        if(result == "")
        {
            Console.Write(i);
        } 

        Console.Write(result);
    }
}

Generate(105);