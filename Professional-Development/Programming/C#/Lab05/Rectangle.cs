namespace Lab05;

internal class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }
    public string Color { get; set; } = "White";
    public string Unit { get; set; } = "cm"; // default
    public int Id { get; } // readonly
    public double Area => Width * Height; // computed
}
