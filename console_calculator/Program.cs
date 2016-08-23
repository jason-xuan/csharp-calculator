using calaulator_core.scanner;
using System;
using System.IO;

namespace console_calculator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string text = "(50+60*70)^80";
            StringReader reader = new StringReader(text);
            Scanner scanner = new Scanner(reader);
            Token token;
            while (true)
            {
                token = scanner.scan();
                if (token == null)
                    break;
                Console.WriteLine(token.ToString());
            }
        }
    }
}
