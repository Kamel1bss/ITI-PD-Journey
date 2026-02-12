namespace Lab04;
internal abstract class Shape
{
    public Shape() { }

    public virtual double CalculateArea()
    {
        return 0;
    }

    public virtual double CalculatePerimeter() 
    {
        return 0;
    }
}
class Circle : Shape
{
    int radius;
    public Circle(int _radius)
    {
        radius = _radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }
}

class Rectangle : Shape
{
    int height;
    int width;
    public Rectangle(int _height, int _width)
    {
        height = _height;
        width = _width;
    }

    public override double CalculateArea()
    {
        return height * width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (height + width);
    }
}

class Triangle : Shape
{
    int len1;
    int len2;
    int len3;
    public Triangle(int _len1, int _len2, int _len3)
    {
        len1 = _len1;
        len2 = _len2;
        len3 = _len3;
    }

    public override double CalculatePerimeter()
    {
        return len1 + len2 + len3;
    }

    public override double CalculateArea()
    {
        double s = CalculatePerimeter() / 2;
        double area = Math.Sqrt(s * (s-len1) * (s-len2) * (s - len3));
        return area;
    }


}
