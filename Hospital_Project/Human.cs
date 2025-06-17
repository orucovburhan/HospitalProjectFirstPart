namespace Hospital_Project;

public abstract class Human
{
    protected Human(string? name, string? surname)
    {
        Name = name;
        Surname = surname;
    }

    public string? Name { get; set; }
    public string? Surname { get; set; }
}