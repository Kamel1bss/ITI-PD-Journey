namespace Lab04;
internal abstract class Animal
{
    public abstract void MakeSound();
    public abstract void Move();
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }

    public override void Move()
    {
        Console.WriteLine("Running on four legs!");
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow! Meow!");
    }
    public override void Move()
    {
        Console.WriteLine("Walking on four legs!");
    }
}

class Bird : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Tweet! Tweet!");
    }

    public override void Move()
    {
        Console.WriteLine("Flying");
    }

}