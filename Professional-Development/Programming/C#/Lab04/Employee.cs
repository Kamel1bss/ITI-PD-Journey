namespace Lab04;
internal class Employee
{
    private int Id { get; set; }
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    public Employee(int _id, string _name, double _salary)
    {
        Id = _id;
        Name = _name;
        BaseSalary = _salary;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Id : {Id}\nName: {Name}\nSalary: {BaseSalary}\n");
    }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

class Manager : Employee
{
    public double Bouns {  get; set; }
    public int TeamSize { get; set; }

    public Manager(int _id, string _name, double _sal, double _bouns, int _teamSize) : base(_id, _name, _sal)
    {
        Bouns = _bouns;
        TeamSize = _teamSize;
    }

    public override double CalculateSalary()
    {
        return base.CalculateSalary() + Bouns;
    }

}

class Developer : Employee
{
    public string Language { get; set; }
    public string[] Projects { get; set; }
    public Developer(int _id, string _name, double _sal, string _lang, string[] _projects) : base(_id, _name, _sal)
    {
        Language = _lang;
        Projects = _projects;
    }


}

class Intern : Employee
{
    public string University { get; set; }
    public int Duration { get; set; }

    public Intern(int _id, string _name, double _sal, string _uni, int _due) : base(_id, _name, _sal)
    {
        University = _uni;
        Duration = _due;
    }
}
