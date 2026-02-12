namespace Lab06;

internal class Handler
{
    public void OnClick(object sender, string button)
    {
        Console.WriteLine("Handler click");   
        Console.WriteLine($"{sender}, {button}");   
    }
}
