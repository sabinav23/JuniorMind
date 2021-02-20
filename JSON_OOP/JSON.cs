using System;
using System.IO;

namespace JSONoop
{
    class JSON
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || (string.IsNullOrEmpty(args[0]) && !File.Exists(args[0])))
            {
                Console.WriteLine("You must insert the path to an existing file.");
                return;
            }

            string path = args[0];
            Value val = new Value();
            string text = System.IO.File.ReadAllText(path);
            var match = val.Match(text);

            if (match.RemainingText() == "" && match.Success())
            {
                Console.WriteLine("Text is a valid JSON");
            }
            else
            {
                Console.WriteLine("Text is not a valid JSON");
            }

        }
    }
}
