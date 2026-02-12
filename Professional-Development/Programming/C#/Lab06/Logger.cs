namespace Lab06;

internal class Logger
{
    public void LogClick(object sender, string button)
    {
        Console.WriteLine("Logger click");
        Console.WriteLine($"{sender}, {button}");
    }
}
