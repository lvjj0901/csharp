public class Student
{
    private string _name;
    private int _age;
    private string _address;

    public Student()
    { 
        this._name = "Unknown";
        this._age = 0;
    }
    public Student(string name, int age)
    { 
        this._name = name;
        this._age = age;
    }
    public Student(string name, int age, string address) : this(name, age)
    {
        this._address = address;
    }
}
