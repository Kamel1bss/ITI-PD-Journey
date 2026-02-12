namespace Lab06;
internal static class Notification
{
    public static void SendEmail(string msg)
    {
        Console.WriteLine($"Email sent: {msg}");
    }
    public static void SendSMS(string msg)
    {
        Console.WriteLine($"SMS sent: {msg}");
    }
    public static void LogToFile(string msg)
    {
        Console.WriteLine($"Logged: {msg}");
    }
}
