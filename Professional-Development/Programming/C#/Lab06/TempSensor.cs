namespace Lab06;

internal static class TempSensor
{
    public static void OnHighTemp(string txt, double temp)
    {
        Console.WriteLine($"{txt} it's {temp}c");
        Console.WriteLine("Take off your cloths!"); 
    }
    public static void OnLowTemp(string txt, double temp)
    {
        Console.WriteLine($"{txt} it's {temp}c");
        Console.WriteLine("Wear one more layer!"); 
    }
}
