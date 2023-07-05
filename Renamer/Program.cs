using Renamer;

class Program
{
    static void Main(string[] args)
    {

        int RUN_DEBUG = 0;

        if(RUN_DEBUG == 1)
        {
            runTests();
            Console.ReadKey();
            return;
        }

        List<string> files;

        if(args.Length != 0)
        {

            //wenn 2 argumente übergeben
            if (args.Length == 2)
            {
                //beide argumente nicht identisch
                if (!args[0].Equals(args[1]))
                {

                    try
                    {

                        files = new List<string>(Directory.GetFiles(Directory.GetCurrentDirectory(), "*", SearchOption.AllDirectories));

                        Matcher.matcher(files, args[0], args[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                else
                {
                    Console.WriteLine("Both arguments are identical!");
                }
            }
            else
            {
                Console.WriteLine("renamer expects 2 arguments!");
            }
        }
        else
        {
            Console.WriteLine("Bitte Argumente übergeben!");
        }

    }

    static void runTests()
    {
        Console.WriteLine("Run all Matcher Tests");

    }
}

