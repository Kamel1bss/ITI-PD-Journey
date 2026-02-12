namespace Lab06;
internal class TempMonitor
{
    public delegate void TemperatureHandler(string txt, double temp);
    public static event TemperatureHandler TemperatureHigh;
    public static event TemperatureHandler TemperatureLow;

    public static void SetTemperature(double temp)
    {
        if (temp > 30)
        {
            if (TemperatureHigh != null)
                TemperatureHigh("Warning!", temp);
        }

        if (temp < 5) {
            if (TemperatureLow != null)
                TemperatureLow("Warning!", temp);
        }
    } 
}
