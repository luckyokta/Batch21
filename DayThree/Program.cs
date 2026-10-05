using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace Classes
{
    public class Program
    {
        static void Main()
        {
            Cat cat = new Cat("Bubu", 2);
        }
    }
    public class Cat
    {
        private string _name;
        private int _age = 0;
        private static int _totalCat = 0;
        public static readonly int Legs = 4;
        public static readonly int eyes = 2;
        public static int TotalCat => _totalCat;
        private bool _isPlaying, _isHunting, _isSleep;

        public Cat(string name, int age)
        {
            this._name = name ?? "Catty the Cat";
            this._age = age;


            _totalCat++;
            Console.WriteLine($"New Cat appeared. He is {name}. Total cat: {TotalCat}");
        }
    }
}