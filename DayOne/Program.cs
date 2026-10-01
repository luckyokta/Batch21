// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata;
using System.Xml;

namespace SampleProcessing
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("====================================");
            Console.WriteLine("SAMPLE PROCESSING START");
            Console.WriteLine("====================================");
            Console.WriteLine();

            SampleEnter();
            CalculateOpticalDensity();

            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine("SAMPLE PROCESSING END");
            Console.WriteLine("====================================");
        }

        static double SampleEnter()
        {
            string sampleName = "Lactobacillus sp.";
            int plateNumber = 1;
            double concentration = 120.5;
            bool isProcessed = false;

            Console.WriteLine($"Sample info: {sampleName}, Plate No. {plateNumber}, Concentration {concentration}");
            Console.WriteLine($"Is Processed: {isProcessed}");

            return concentration;
        }

        static void CalculateOpticalDensity()
        {
            Console.WriteLine();
            Console.WriteLine("====PROCESSING====");
            Console.WriteLine();

            double slope = 0.5;
            double interceptConstant = 0.125;
            double concentration = SampleEnter();

            double opticalDensity = (slope * concentration) + interceptConstant;
            Console.WriteLine($"Optical Density: {opticalDensity}");
        }
    }
}


