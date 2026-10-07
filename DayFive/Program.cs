// See https://aka.ms/new-console-template for more information
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Xml.XPath;

namespace Delegates
{
    class Program
    {
        static void Main()
        {
            BasicDelegate();
            DelegateAsParameter();
            RunsOperations(10, 5, operation);
        }

        delegate int Operation(int x, int y);

        static int Add(int a, int b) => a + b;
        static int Multiply(int a, int b)=> a * b;
        static int Subtract(int a, int b) => a - b;
        static int Divide(int a, int b) => a / b;

        // BASIC DELEGATES
        static void BasicDelegate()
        {
            Console.WriteLine("==== BASIC DELEGATE ====");
            Operation operation = Add;
            int result = operation(2, 3);
            Console.WriteLine($"Add of 2 and 3 through delegate = {result}");

            operation = Multiply;
            result = operation(2, 3);
            Console.WriteLine($"Multiply of 2 and 3 through delegate = {result}");
        }

        static int ExecuteOperation(int x, int y, Operation operation)
        {
            return operation(x, y);
        }

        static void DelegateAsParameter()
        {
            Console.WriteLine("\nThese output is using delegate as parameter");
            Console.WriteLine($"Add: {ExecuteOperation(10, 5, Add)}");
            Console.WriteLine($"Multiply: {ExecuteOperation(10, 5, Multiply)}");
            Console.WriteLine($"Subtract: {ExecuteOperation(10, 5, Subtract)}");
        }

        // PLUGIN METHOD WITH DELEGATE
        static void RunsOperations(int x, int y, Operation[] operation)
        {
            Console.WriteLine("\n==== PLUGIN METHOD WITH DELEGATE ====");
            Console.WriteLine("These outputs are the result of addition, multiplication, subtraction and dividion of 10 and 5 respectively");
            foreach(Operation o in operation)
            {
                Console.Write($" {o(x, y)}");
            }
        }

        static Operation[] operation = {Add, Multiply, Subtract, Divide};

        
    }
} 