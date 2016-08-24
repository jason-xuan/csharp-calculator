using calaulator_core.scanner;
using System;
using System.IO;
using calaulator_core.parser;
using System.Collections;
namespace console_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            Parser parser = new Parser();
            Console.WriteLine("welcome to the calculation world!");
            while (true)
            {
                try
                {
                    Console.Write(">>> ");
                    text = Console.ReadLine();
                    if (text == "")
                    {
                        continue;
                    }
                    Node node = parser.Parse(text);
                    Console.WriteLine("\t"+node.Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            
        }
    }
}
