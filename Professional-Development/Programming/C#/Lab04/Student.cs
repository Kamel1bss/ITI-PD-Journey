namespace Lab04;
internal class Student
{
    int id;
    string name;
    int age;

    public Student()
    {
        
    }
    public int Id { 
        get { return id; }
        set { id = value;} 
    }
    public string Name { 
        get { return name; }
        set { name = value; }
    }
    public int Age {
        get { return age; } 
        set { 
            if(value >= 16 && value <= 100)
                age = value; 
        } 
    }
}
