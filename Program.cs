Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("ProgLang V0.1 ©2023 Reuben Waring");
Console.Title = "ProgLang CLI";
Console.ForegroundColor = ConsoleColor.White;
while (true)
{
    var inp = Console.ReadLine();
    if (inp![0] == '@')
    {
        StreamReader sr = new StreamReader(inp);
        Execute(sr.ReadToEnd());
    }
    else
    {
        Execute(inp);
    }
}
static void Execute(string code)
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(DateTime.Now);
    Console.ForegroundColor = ConsoleColor.White;
    var lines = code.Split(new string[] { "\\n" }, StringSplitOptions.None);
    foreach(string line in lines)
    {
        var linesplit = line.Split(' ');
        foreach(string item in linesplit)
        {
            if(item=="display")
            {
                if (linesplit[Array.IndexOf(linesplit, item) + 1][0] == '"')
                {
                    var lslast = linesplit.Last();
                    for (int i = Array.IndexOf(linesplit, item) + 1; i < linesplit.Length; i++)
                    {
                        foreach (char character in linesplit[i])
                        {
                            if (character == '"')
                            {
                                continue;
                            }
                            if (character == '¬')
                            {
                                Console.Write(" ");
                                continue;
                            }
                            if (character == '&')
                            {
                                Console.Write(Globals.Variables[Globals.Variables.IndexOf(item + 3)+3]);
                                goto biscuit;
                            }
                            Console.Write(character);
                        }
                    }
                biscuit:;
                }
                else
                {
                    Console.WriteLine(Globals.Variables[Globals.Variables.IndexOf(linesplit[Array.IndexOf(linesplit, item) + 1])+1]);
                }
                Console.Write(Environment.NewLine);
            }
            //Keyword: make
            //Declares a variable and assigns a value
            //make datatype variablename = variablevalue
            if (item == "make")
            {
                Globals.Variables.Add(linesplit[Array.IndexOf(linesplit, item) + 1]);
                Globals.Variables.Add(linesplit[Array.IndexOf(linesplit, item) + 2]);
                Globals.Variables.Add(linesplit[Array.IndexOf(linesplit, item) + 4]);
            }
        }
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Execution successfully completed at " + DateTime.Now);
    Console.ForegroundColor = ConsoleColor.White;
}
public class Globals
{
    public static List<Object> Variables = new List<object>();
}