using System.Data;
using System.Security;

class FooBarGenerator
{
    static Dictionary<int, string> rules = new();

    static void Main()
    {
        AddRule(3, "foo");
        AddRule(4, "baz");
        AddRule(5, "bar");
        AddRule(7, "jazz");
        AddRule(9, "huzz");
        Console.WriteLine(Evaluate(36));
        Console.WriteLine(GenerateSequence(1, 36));
    }

    static void AddRule(int divisor, string output)
    {
        rules[divisor] = output;
    }

    static string Evaluate(int number)
    {
        List<string> outputs = new();

        foreach(var rule in rules.OrderBy(r => r.Key))
        {
            if(number % rule.Key == 0)
            {
                outputs.Add(rule.Value);
            }
        }

        if(outputs.Count == 0)
        {
            string output = number.ToString();

            return output;
        }

        return string.Concat(outputs);
    }

    static string GenerateSequence(int start, int end)
    {
        List<string> results = new();

        for(int i = start; i <= end; i++)
        {
            results.Add(Evaluate(i));
        }

        return string.Join(", ", results);
    }
}