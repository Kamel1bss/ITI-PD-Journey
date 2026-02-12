namespace Lab05;

internal class Person
{
    public string FName {  get; set; }
    public string LName { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Name: {FName} {LName}\nage: {Age}";
    }

}
