namespace Lab04;

internal interface IMovable
{
    void Move();
    void Stop();
    int GetSpeed();
}

internal interface IChargeable
{
    void Charge(int _amount);
}

class Car : IMovable
{
    int speed;
    public Car(int _speed)
    {
        speed = _speed;
    }
    public void Move()
    {
        Console.WriteLine($"Driving with\n speed: {speed}");
    }

    public void Stop()
    {
        Console.WriteLine($"Braking!!");
    }
    public int GetSpeed()
    {
        return speed;
    }
}

class Robot : IMovable, IChargeable
{
    int charge;
    int speed;
    public Robot(int _speed, int _charge)
    {
        speed = _speed;
        charge = _charge;
    }
    public void Charge(int _amount)
    {
        charge = _amount;
    }

    public int GetSpeed()
    {
        return speed;
    }

    public void Move()
    {
        Console.WriteLine($"Walking with\n Speed: {speed}\nCharge: {charge}");

    }

    public void Stop()
    {
        Console.WriteLine("Halting!!");
    }
}
